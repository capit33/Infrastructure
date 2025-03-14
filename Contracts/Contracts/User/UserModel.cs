using Contracts.Interface.User;
using System;

namespace Contracts.User;

public class UserModel : BaseUser, IUser
{
    public DateTime? BirthDate { get; set; }
    public string AddresseeForm { get; set; }

    public string NormalizedFirstName { get => FirstName.ToUpperInvariant(); } 

    public string NormalizedLastName { get => FirstName.ToUpperInvariant(); }

}
