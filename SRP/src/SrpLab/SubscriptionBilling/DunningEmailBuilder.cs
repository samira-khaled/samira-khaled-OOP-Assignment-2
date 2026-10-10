using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.SubscriptionBilling
{
    public class DunningEmailBuilder
    {
        public string BuildDunningEmail(string customerName, DateOnly asOf, int failedPayments, decimal amount, string invoice)
        {
            // Collections tone & legal boilerplate ≠ proration formula.
            var severity = failedPayments switch
            {
                <= 1 => "friendly reminder",
                2 => "second notice",
                _ => "final notice before suspension"
            };
            return $"Subject: {severity} {invoice}\nHi {customerName},\nBalance {amount:C} as of {asOf:o} ({failedPayments} failures).\n";
        }
    }
}
