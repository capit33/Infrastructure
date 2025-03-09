using Contracts.Interface.User;
using System.Collections.Generic;

namespace Infrastructure.Interfaces;

public interface IBaseFakerManager
{
    string GetRandomString(int count, string separat = " ", int from = 0, int till = 10);
    T GetRandomItem<T>(List<T> itemList);
    T GetUser<T>() where T : class, IUser, new();
    public List<T> GetUsers<T>(int count) where T : class, IUser, new();
}
