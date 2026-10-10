using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.SubscriptionBilling
{
    public class ProrationCalculator
    {
        public decimal CalculateProratedAmount(decimal monthlyPrice, DateOnly periodStart, DateOnly periodEnd, DateOnly activeFrom)
        {
            // Finance calendar rules change independently of email copy.
            if (activeFrom <= periodStart) return monthlyPrice;
            if (activeFrom >= periodEnd) return 0m;
            var totalDays = periodEnd.DayNumber - periodStart.DayNumber;
            if (totalDays <= 0) return monthlyPrice;
            var used = periodEnd.DayNumber - activeFrom.DayNumber;
            return Math.Round(monthlyPrice * used / totalDays, 2);
        }
    }
}
