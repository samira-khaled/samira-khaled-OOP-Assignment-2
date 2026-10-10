using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.LoanDesk
{
    public class LoanDecisionLetterBuilder
    {
        public string BuildDecisionLetter(string applicantName, decimal requestedAmount, decimal riskScore, bool isEligible, IReadOnlyList<string> requiredDocuments)
        {
            // Legal/comms wording ≠ underwriting math.
            if (isEligible)
            {
                return $"Dear {applicantName},\nYour request for {requestedAmount:C} is pre-approved (risk {riskScore:0}).\n" +
                       $"Please upload: {string.Join("; ", requiredDocuments)}.\n";
            }

            return $"Dear {applicantName},\nWe are unable to approve {requestedAmount:C} at this time.\n" +
                   $"Reference risk={riskScore:0}. You may reapply after improving documentation.\n";
        }
    }
}
