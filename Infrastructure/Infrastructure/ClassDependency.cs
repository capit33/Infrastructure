using Infrastructure.BLL;
using Infrastructure.BLL.Interface;
using Infrastructure.DAL;
using Infrastructure.DAL.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class  ClassDependency
{
    public static void AddBaseClassDependency(this IServiceCollection services)
    {
        services.AddScoped<IBaseUserManager, BaseUserManager>();
        services.AddScoped<IBaseUserRepository, BaseUserRepository>();
    }
}
