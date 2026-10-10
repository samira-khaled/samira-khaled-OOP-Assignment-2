using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.LoanDesk
{
    public class LoanAssessment
    {
        public decimal CalculateRiskScore(int creditScore, int employmentMonths, decimal requestedAmount, bool hasCollateral)
        {
            // Risk model will change with risk committee — not with letter templates.
            decimal score = 100m;
            score -= Math.Max(0, 700 - creditScore) * 0.15m;
            if (employmentMonths < 6) score -= 20m;
            if (requestedAmount > 50_000m && !hasCollateral) score -= 25m;
            if (requestedAmount > 150_000m) score -= 10m;
            return Math.Clamp(score, 0m, 100m);
        }

        public bool IsEligible(int creditScore, int employmentMonths, decimal requestedAmount, bool hasCollateral)
        {
            return CalculateRiskScore(creditScore, employmentMonths, requestedAmount, hasCollateral) >= 55m && creditScore >= 580;
        }
        
    }
}
