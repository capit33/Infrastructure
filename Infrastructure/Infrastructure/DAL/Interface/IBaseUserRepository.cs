using Contracts.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.DAL.Interface;

public interface IBaseUserRepository
{
    public Task<List<UserModel>> GetUserModelsAsync();
    public Task SaveAsync(UserModel user);
}
