using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.AppointmentDesk
{
    public class SmsReminderFormatter
    {
        public string FormatSmsReminder(DateTimeOffset slot, string clinicPhone)
        {
            // Messaging channel copy — fourth concern hiding in the "scheduler".
            return $"Reminder: appointment {slot:MMM dd HH:mm}. Call {clinicPhone} to reschedule.";
        }

    }
}
