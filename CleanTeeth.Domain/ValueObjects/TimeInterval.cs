using CleanTeeth.Domain.Exceptions;

namespace CleanTeeth.Domain.ValueObjects;

public class TimeInterval
{
    public DateTime Start { get; private set; }
    public DateTime End { get; private set; }

    public TimeInterval(DateTime start, DateTime end)
    {
        if (start >= end)
        {
            throw new BussinessRuleException("Start time must be before end time.");
        }

        Start = start;
        End = end;
    }
}
