using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.LoanDesk
{
    public class UnderwriterCsvExporter
    {
        public string BuildCsvRow(string applicationId, int creditScore, int employmentMonths, bool hasCollateral, decimal riskScore, bool isEligible)
        {
            // Analytics export schema is yet another reason to change.
            return $"{applicationId},{creditScore},{employmentMonths},{(hasCollateral ? 1 : 0)},{riskScore:0.00},{(isEligible ? "Y" : "N")}";
        }
    }
}
