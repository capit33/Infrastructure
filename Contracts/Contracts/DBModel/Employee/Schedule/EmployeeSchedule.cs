using Contracts.Base.Date;using Contracts.Enum.Schedule;namespace Contracts.DBModel.Employee.Schedule;public class EmployeeSchedule{
    #region Properties
    public string Id { get; set; }    public string Name { get; set; }    public string Description { get; set; }    public string UserId { get; set; }    public string GroupId { get; set; }    public DateRange WorkingTime { get; set; }    public string CoveringUserId { get; set; }    public ScheduleStatus Status { get; set; }    public EmployeeScheduleCoveringType CoveringType { get; set; }

    #endregion
    #region Constructors
    #endregion
    #region General Methods
    #endregion

}