using System;

namespace Contracts.Base.Date;

public class TimeKey
{
    public TimeOnly Time { get; set; }
    public int Index { get; set; }

    public TimeKey(TimeOnly time, int index)
    {
        Time = time;
        Index = index;
    }
}
