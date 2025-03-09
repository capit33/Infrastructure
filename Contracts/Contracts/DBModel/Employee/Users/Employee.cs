using Contracts.DBModel.Employee.Group;
using System;
using System.Collections.Generic;

namespace Contracts.DBModel.Employee.Users;

public class Employee
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public DateTime? BirthDate { get; set; }
    public string Color { get; set; }
    public string AddresseeForm { get; set; }
    public List<EmployeeGroupEntry> GroupEntries { get; set; }
}
