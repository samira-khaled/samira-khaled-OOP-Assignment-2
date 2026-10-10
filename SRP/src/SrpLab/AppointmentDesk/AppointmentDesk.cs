namespace SrpLab.AppointmentDesk;

/// <summary>
/// Appointment desk: opening-hours rules, slot search, and ICS calendar blob generation.
/// </summary>
public sealed class AppointmentDesk
{
   
    public TimeOnly Open { get; }
    public TimeOnly Close { get; }
    public int SlotMinutes { get; }
    private readonly SmsReminderFormatter smsReminderFormatter = new();
    private readonly IcsCalendarFormatter icsCalendarBuilder = new();
    private readonly AppointmentScheduler appointmentHoursPolicy;

    public AppointmentDesk(TimeOnly open, TimeOnly close, int slotMinutes)
    {
        Open = open;
        Close = close;
        SlotMinutes = slotMinutes;
        appointmentHoursPolicy = new AppointmentScheduler(open, close, slotMinutes);
    }

    public bool IsWithinBusinessHours(DateTimeOffset when)
    {
        return appointmentHoursPolicy.IsWithinBusinessHoursbuilder(when);
    }

    public DateTimeOffset? FindNextSlot(DateTimeOffset from, int searchHours)
    {
        return appointmentHoursPolicy.FindNextSlotbuilder(from, searchHours);
    }

    public bool TryBook(DateTimeOffset slot)
    {
        return appointmentHoursPolicy.TryBook(slot);
    }

    public string ToIcs(DateTimeOffset slot, string patientName, string clinician)
    {
        
        return icsCalendarBuilder.FormatIcs(slot, patientName, clinician, SlotMinutes);

    }

    public string SmsReminder(DateTimeOffset slot, string clinicPhone)
    {
        return smsReminderFormatter.FormatSmsReminder(slot, clinicPhone);
    }

   
}
