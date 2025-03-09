using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.BaseModels;

public class BaseRestClient
{
    private const string MEDIA_TIPE = "application/json";
    private const double REQUEST_TIMEOUT_SECOND = 10_000;

    private readonly HttpClient _httpClient;
    private readonly Uri _uriBase;

    public BaseRestClient(IConfiguration configuration, string serviceName, IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();

        _httpClient.Timeout = TimeSpan.FromSeconds(REQUEST_TIMEOUT_SECOND);

        var url = configuration.GetSection("ServiceUrl")[serviceName];

        if (string.IsNullOrEmpty(url))
            throw new InvalidOperationException();

        _uriBase = new Uri(url);
    }

    public async Task<T> GetAsync<T>(string path)
        where T : class
    {
        var requestMessage = new HttpRequestMessage(HttpMethod.Get, GetUri(path));

        var responseMessage = await _httpClient.SendAsync(requestMessage);
        var content = await responseMessage.Content.ReadAsStringAsync();

        if (responseMessage.IsSuccessStatusCode)
        {
            if (typeof(T) == typeof(string))
                return (T)Convert.ChangeType(content, typeof(T));

            return JsonConvert.DeserializeObject<T>(content);
        }
        else
        {
            throw new Exception($"{responseMessage.StatusCode.ToString()}: {content}");
        }
    }

    public async Task<T> PostAsync<T, TY>(string path, TY request)
        where T : class
        where TY : class
    {
        var requestMessage = new HttpRequestMessage(HttpMethod.Post, GetUri(path));

        requestMessage.Content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, MEDIA_TIPE);
        var responseMessage = await _httpClient.SendAsync(requestMessage);
        var content = await responseMessage.Content.ReadAsStringAsync();

        if (responseMessage.IsSuccessStatusCode)
        {
            if (typeof(T) == typeof(string))
                return (T)Convert.ChangeType(content, typeof(T));

            return JsonConvert.DeserializeObject<T>(content);
        }
        else
        {
            throw new Exception($"{responseMessage.StatusCode.ToString()}: {content}");
        }
    }
    public async Task<T> PatchAsync<T>(string path)
        where T : class
    {
        var requestMessage = new HttpRequestMessage(HttpMethod.Patch, GetUri(path));

        var responseMessage = await _httpClient.SendAsync(requestMessage);
        var content = await responseMessage.Content.ReadAsStringAsync();

        if (responseMessage.IsSuccessStatusCode)
        {
            if (typeof(T) == typeof(string))
                return (T)Convert.ChangeType(content, typeof(T));

            return JsonConvert.DeserializeObject<T>(content);
        }
        else
        {
            throw new Exception($"{responseMessage.StatusCode.ToString()}: {content}");
        }
    }

    public async Task<T> PatchAsync<T, TY>(string path, TY request)
        where T : class
        where TY : class
    {
        var requestMessage = new HttpRequestMessage(HttpMethod.Patch, GetUri(path));


        requestMessage.Content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, MEDIA_TIPE);
        var responseMessage = await _httpClient.SendAsync(requestMessage);
        var content = await responseMessage.Content.ReadAsStringAsync();

        if (responseMessage.IsSuccessStatusCode)
        {
            if (typeof(T) == typeof(string))
                return (T)Convert.ChangeType(content, typeof(T));
            return JsonConvert.DeserializeObject<T>(content);
        }
        else
        {
            throw new Exception($"{responseMessage.StatusCode.ToString()}: {content}");
        }
    }

    public async Task<T> DeleteAsync<T>(string path)
       where T : class
    {
        var requestMessage = new HttpRequestMessage(HttpMethod.Delete, GetUri(path));

        var responseMessage = await _httpClient.SendAsync(requestMessage);
        var content = await responseMessage.Content.ReadAsStringAsync();

        if (typeof(T) == typeof(string))
            return (T)Convert.ChangeType(content, typeof(T));
        return JsonConvert.DeserializeObject<T>(content);
    }

    public async Task<T> DeleteAsync<T, TY>(string path, TY request)
        where T : class
        where TY : class
    {
        var requestMessage = new HttpRequestMessage(HttpMethod.Delete, GetUri(path));

        requestMessage.Content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, MEDIA_TIPE);
        var responseMessage = await _httpClient.SendAsync(requestMessage);
        var content = await responseMessage.Content.ReadAsStringAsync();

        if (responseMessage.IsSuccessStatusCode)
        {
            if (typeof(T) == typeof(string))
                return (T)Convert.ChangeType(content, typeof(T));
            return JsonConvert.DeserializeObject<T>(content);
        }
        else
        {
            throw new Exception($"{responseMessage.StatusCode.ToString()}: {content}");
        }
    }

    private Uri GetUri(string path)
    {
        return new Uri(_uriBase, path);
    }
}
