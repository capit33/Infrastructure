using Contracts.Interface.User;

namespace Contracts.User;

public class BaseUser : IBaseUser
{
    public string FirstName { get; set ; }
    public string LastName { get; set; }
}
