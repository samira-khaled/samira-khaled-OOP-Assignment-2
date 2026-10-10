using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.SupportTicket
{
    public class TicketMessageBuilder
    {
        public string BuildPublicReply(string agentName, string Id, string Priority, DateTimeOffset SlaDeadline)
        {
            // Tone/templates owned by CX — not by SLA engineering.
            var apology = Priority == "P1" ? "We are treating this as a critical incident." : "Thanks for reaching out.";
            return $"Hi,\n{apology}\nTicket {Id} is with {agentName}. Next update before {SlaDeadline:u}.\n";
        }

        public string BuildInternalEscalationBlurb(string Id, string Priority, DateTimeOffset SlaDeadline)
        {
            return $"ESCALATE {Id} priority={Priority} breachAt={SlaDeadline:u} keywords-scanned=yes";
        }
    }
}
