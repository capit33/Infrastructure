using Contracts.User;
using Infrastructure.BaseModels;
using Infrastructure.DAL.Interface;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.DAL;

public class BaseUserRepository : BaseMongoRepository<UserModel>, IBaseUserRepository
{
    private static bool IsInitialized { get; set; }

    public BaseUserRepository(IConfiguration configuration)
        : base(configuration, "userTestModel")
    {
    }

    public async Task<List<UserModel>> GetUserModelsAsync()
    {
        return await Collection.Find(Filter.Empty)
            .SortBy(u => u.FirstName)
            .ThenBy(u => u.LastName)
            .ToListAsync();
    }

    public async Task SaveAsync(UserModel user)
    {
        user.Id ??= ObjectId.GenerateNewId().ToString();

        await Collection.InsertOneAsync(user);
    }

    protected override bool CollectionInitialized() => IsInitialized;

    protected override async Task InitializeCollectionAsync()
    {
        var indexes = new List<CreateIndexModel<UserModel>>
                {
                    new CreateIndexModel<UserModel>(Builders<UserModel>.IndexKeys
                            .Descending(e => e.FirstName)
                            .Descending(e => e.LastName),
                        new CreateIndexOptions
                        {
                            Background = true
                        }),

                };

        await Collection.Indexes.CreateManyAsync(indexes).ConfigureAwait(false);
        IsInitialized = true;
    }
}
