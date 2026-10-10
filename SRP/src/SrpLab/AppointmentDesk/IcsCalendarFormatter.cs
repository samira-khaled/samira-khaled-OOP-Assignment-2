using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.AppointmentDesk
{
    public class IcsCalendarFormatter
    {
        public string FormatIcs(DateTimeOffset slot, string patientName, string clinician,int slotMinutes)
        {
            var uid = Guid.NewGuid();
            var end = slot.AddMinutes(slotMinutes);

            return "BEGIN:VCALENDAR\nVERSION:2.0\nBEGIN:VEVENT\n" +
                   $"UID:{uid}\nDTSTART:{slot:yyyyMMdd'T'HHmmss'Z'}\nDTEND:{end:yyyyMMdd'T'HHmmss'Z'}\n" +
                   $"SUMMARY:Visit {patientName} / {clinician}\nEND:VEVENT\nEND:VCALENDAR\n";
        }
    }
}
