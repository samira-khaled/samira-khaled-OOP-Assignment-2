
namespace SrpLab.AppointmentDesk;

public class AppointmentScheduler
{
    private readonly HashSet<DateTimeOffset> _booked = new();

    public TimeOnly Open { get; }
    public TimeOnly Close { get; }
    public int SlotMinutes { get; }

    public AppointmentScheduler(TimeOnly open,TimeOnly close,int slotMinutes)
    {
        Open = open;
        Close = close;
        SlotMinutes = slotMinutes;
    }

    public bool IsWithinBusinessHoursbuilder(DateTimeOffset when)
    {
        if (when.DayOfWeek is DayOfWeek.Friday or DayOfWeek.Saturday)
            return false;

        var time = TimeOnly.FromDateTime(when.DateTime);

        return time >= Open
            && time.AddMinutes(SlotMinutes) <= Close;
    }

    public DateTimeOffset? FindNextSlotbuilder(DateTimeOffset from,int searchHours)
    {
        var cursor = Alignbuilder(from);
        var end = from.AddHours(searchHours);

        while (cursor < end)
        {
            if (IsWithinBusinessHoursbuilder(cursor)
                && !_booked.Contains(cursor))
            {
                return cursor;
            }

            cursor = cursor.AddMinutes(SlotMinutes);
        }

        return null;
    }

    public bool TryBook(DateTimeOffset slot)
    {
        if (!IsWithinBusinessHoursbuilder(slot)
            || _booked.Contains(slot))
        {
            return false;
        }

        _booked.Add(slot);
        return true;
    }

    private DateTimeOffset Alignbuilder(DateTimeOffset from)
    {
        var minutes =
            from.Minute - (from.Minute % SlotMinutes);

        return new DateTimeOffset(from.Year,from.Month,from.Day,from.Hour,minutes,0,from.Offset);
    }
}
