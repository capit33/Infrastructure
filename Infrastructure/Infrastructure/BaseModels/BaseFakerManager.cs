using Bogus;
using Contracts.Interface.User;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Infrastructure.BaseModels;

public class BaseFakerManager
{
    private Faker _faker { get; set; }

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

    public string GetRandomColorHex()
    {
        var random = new Random();
        int r = random.Next(100, 256);
        int g = random.Next(100, 256);
        int b = random.Next(100, 256);

        return ColorTranslator.ToHtml(Color.FromArgb(r, g, b));
    }

    public List<T> GetUsers<T>(int count) where T : class, IBaseUser, new()
    {
        var users = new List<T>();

        for (int i = 0; i < count; i++)
        {
            users.Add(GetUser<T>());
        }

        return users;
    }

    private T GetUser<T>() where T : class, IBaseUser, new()
    {
        var faker = new Faker<T>()
            .RuleFor(e => e.FirstName, f => f.Name.FirstName().ToUpperInvariant())
            .RuleFor(e => e.LastName, f => f.Name.LastName().ToUpperInvariant());

        if (typeof(IUser).IsAssignableFrom(typeof(T)))
        {
            faker.RuleFor(e => ((IUser)(object)e).BirthDate, f => f.Date.Past(30, DateTime.Now.AddYears(-18)))
                 .RuleFor(e => ((IUser)(object)e).AddresseeForm, f => f.Address.FullAddress());
        }
        
        return faker.Generate();
    }
}
