using System.Collections.Generic;

namespace Contracts.Enum.Schedule;

public enum ScheduleStatus
{
    Working,
    SickLeave,
    Vacation,
    Unavailable,
    DayOff,
    Weekend,
    Holiday,
    OfficeTime,
    CallCenter
}

public static class ScheduleStatusExtensions
{
    /// <summary>
    /// Get schedule statuses 
    /// </summary>
    /// <returns></returns>
    public static List<ScheduleStatus> GetHolidayStatuses()
        => new List<ScheduleStatus> { ScheduleStatus.Holiday, ScheduleStatus.Weekend };

    public static bool IsUnavailable(this ScheduleStatus status)
    {
        switch (status)
        {
            case ScheduleStatus.SickLeave:
            case ScheduleStatus.Vacation:
            case ScheduleStatus.Unavailable:
            case ScheduleStatus.DayOff:
            case ScheduleStatus.Weekend:
            case ScheduleStatus.Holiday:
                return true;
            default:
                return false;
        }
    }

    public static bool ServiceStatus(this ScheduleStatus status)
    {
        switch (status)
        {
            case ScheduleStatus.OfficeTime:
            case ScheduleStatus.CallCenter:
                return true;
            default:
                return false;
        }
    }

    public static bool CoveringStatus(this ScheduleStatus status)
    {
        switch (status)
        {
            case ScheduleStatus.Vacation:
            case ScheduleStatus.SickLeave:
            case ScheduleStatus.DayOff:
            case ScheduleStatus.Unavailable:
                return true;
            default:
                return false;
        }
    }
}
