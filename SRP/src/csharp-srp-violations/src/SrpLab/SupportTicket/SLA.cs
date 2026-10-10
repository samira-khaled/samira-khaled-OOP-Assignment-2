using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.SupportTicket
{
    public class SLA
    {
        public DateTimeOffset Sla(string Priority, DateTimeOffset OpenedAt)
        {
            // Operational SLA policy — different stakeholders than reply wording.
            var hours = Priority switch
            {
                "P1" => 4,
                "P2" => 24,
                _ => 72
            };
            return OpenedAt.AddHours(hours);
        }
        public bool IsBreached(DateTimeOffset now, string Priority, DateTimeOffset OpenedAt)
        {
            return now > Sla(Priority, OpenedAt);
        }
    }
}
