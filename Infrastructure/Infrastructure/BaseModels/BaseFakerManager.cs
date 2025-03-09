using Bogus;
using Infrastructure.Interfaces;
using System.Collections.Generic;
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
}
