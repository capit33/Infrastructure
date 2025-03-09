using Bogus;
using Contracts.Interface.User;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Infrastructure.BaseModels;

public class BaseFakerManager : IBaseFakerManager
{
    private Faker _faker;

    public BaseFakerManager()
    {
        _faker = new Faker();
    }

    public string GetRandomString(int count, string separat = " ", int from = 0, int till = 10)
    {
        var list = GetRandomIntList(count, from, till);

        var text = string.Join(separat, list);
        return text;    
    }

    public List<int> GetRandomIntList(int count, int from = 0, int till = 10)
    {
        var range = Enumerable.Range(from, till - from + 1);
        var randomized = _faker.Random.Shuffle(range);
        var list = randomized.Take(count).ToList();

        return list;
    }

    public T GetRandomItem<T>(List<T> itemList)
    {
        return _faker.PickRandom(itemList);
    }

    public static string GetRandomColorHex()
    {
        var random = new Random();
        int r = random.Next(100, 256);
        int g = random.Next(100, 256);
        int b = random.Next(100, 256);

        return ColorTranslator.ToHtml(Color.FromArgb(r, g, b));
    }

    public T GetUser<T>() where T : class, IUser, new()
    {
        // Створення фейкера для типу T
        var faker = new Faker<T>()
            .RuleFor(e => e.FirstName, f => f.Name.FirstName())
            .RuleFor(e => e.LastName, f => f.Name.LastName())
            .RuleFor(e => e.BirthDate, f => f.Date.Past(30, DateTime.Now.AddYears(-18)))
            .RuleFor(e => e.AddresseeForm, f => f.Address.FullAddress());

        return faker.Generate();
    }

    public List<T> GetUsers<T>(int count) where T : class, IUser, new()
    {
        var users = new List<T>();

        for (int i = 0; i < count; i++)
        {
            users.Add(GetUser<T>());
        }

        return users;
    }
}
