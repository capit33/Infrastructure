namespace Contracts.DBModel.Employee.Group;

public class EmployeeGroupEntry
{
    public string Id { get; set; }
    public string Name { get; set; }

    public EmployeeGroupEntry()
    {
    }

    public EmployeeGroupEntry(EmployeeGroup group)
    {
        Id = group.Id;
        Name = group.Name;
    }
}
