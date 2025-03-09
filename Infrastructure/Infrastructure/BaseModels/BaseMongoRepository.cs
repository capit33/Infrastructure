using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Infrastructure.BaseModels;

public class BaseMongoRepository<T> where T : class
{
    protected IMongoCollection<T> Collection { get; }

    protected FilterDefinitionBuilder<T> Filter = Builders<T>.Filter;
    protected UpdateDefinitionBuilder<T> Update = Builders<T>.Update;

    protected readonly FindOneAndUpdateOptions<T, T> UpdateOptions = new FindOneAndUpdateOptions<T, T>()
    {
        ReturnDocument = ReturnDocument.After
    };

    protected readonly FindOneAndUpdateOptions<T, T> UpsertOptions = new FindOneAndUpdateOptions<T, T>()
    {
        ReturnDocument = ReturnDocument.After,
        IsUpsert = true
    };

    public BaseMongoRepository(IConfiguration configuration, string collectionName)
    {
        var connectionString = configuration["MongoDBConnectionString"];
        var mongoUrl = new MongoUrl(connectionString);
        var settings = MongoClientSettings.FromConnectionString(connectionString);
        var client = new MongoClient(settings);
        Collection = client.GetDatabase(mongoUrl.DatabaseName).GetCollection<T>(collectionName);
    }
}
