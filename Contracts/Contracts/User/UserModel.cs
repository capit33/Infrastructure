using Contracts.Interface.User;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Contracts.User;

[BsonIgnoreExtraElements]
public class UserModel : BaseUser, IUser
{
    public string Id { get; set; }
    public DateTime? BirthDate { get; set; }
    public string AddresseeForm { get; set; }

    public string NormalizedFirstName { get => FirstName.ToUpperInvariant(); } 

    public string NormalizedLastName { get => FirstName.ToUpperInvariant(); }

}
