namespace Infrastructure.Interfaces;

public interface IBaseFakerManager
{
    string GetRandomString(int count, string separat = " ", int from = 0, int till = 10);
}
