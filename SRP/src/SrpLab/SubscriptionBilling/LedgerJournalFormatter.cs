using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.SubscriptionBilling
{
    public class LedgerJournalFormatter
    {
        
            public string FormatLedgerJournalLine(string customerId,string invoiceNumber,decimal amount)
            {
                return $"{customerId},{invoiceNumber},{amount:0.00},AR-SUB";
            }
        
    }
}
