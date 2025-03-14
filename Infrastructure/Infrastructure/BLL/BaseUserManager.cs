using Contracts.User;
using Infrastructure.BaseModels;
using Infrastructure.BLL.Interface;
using Infrastructure.DAL.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.BLL;

class BaseUserManager : IBaseUserManager
{
    private BaseFakerManager FakerManager { get; set; }

    private IBaseUserRepository UserReposytory { get; set; }

    public BaseUserManager(IBaseUserRepository userReposytory)
    {
        FakerManager = new BaseFakerManager();
        UserReposytory = userReposytory;
    }

    public async Task<List<UserModel>> GetUserModelsAsync()
    {
        return await UserReposytory.GetUserModelsAsync();
    }

    public async Task SaveAsync(UserModel user)
    {
        await UserReposytory.SaveAsync(user);
    }

    public async Task GenerateUsersAsync(int count)
    {
        var users = FakerManager.GetUsers<UserModel>(count).OrderBy(u => u.NormalizedFirstName).ToList();

        foreach (var user in users)
        {
            await SaveAsync(user);
        }
    }
}
