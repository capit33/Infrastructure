using Contracts.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.BLL.Interface;

public interface IBaseUserManager
{
    public Task GenerateUsersAsync(int count);
    public Task<List<UserModel>> GetUserModelsAsync();
    public Task SaveAsync(UserModel user);
}