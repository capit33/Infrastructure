using System;

namespace Contracts.Interface.User;

public interface IUser : IBaseUser
{
    public DateTime? BirthDate { get; set; }
    public string AddresseeForm { get; set; }
}
