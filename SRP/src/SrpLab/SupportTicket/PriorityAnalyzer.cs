using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.SupportTicket
{
    public class PriorityAnalyzer
    {
        public void CalculatePriority(string Subject, string Body, out string Priority)
        {
            // This is a simple heuristic for determining ticket priority based on keywords in the subject and body.
            // Keyword heuristics will churn with support playbooks; SLA math will not.
            var blob = (Subject + " " + Body).ToLowerInvariant();
            if (blob.Contains("down") || blob.Contains("outage") || blob.Contains("cannot login"))
                Priority = "P1";
            else if (blob.Contains("urgent") || blob.Contains("asap") || blob.Contains("blocked"))
                Priority = "P2";
            else
                Priority = "P3";
        }
    }
}
