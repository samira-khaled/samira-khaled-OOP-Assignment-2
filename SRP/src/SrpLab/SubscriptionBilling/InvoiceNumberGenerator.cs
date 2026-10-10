using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.SubscriptionBilling
{
    public class InvoiceNumberGenerator
    {

        private static int _invoiceSeq = 1000;
        public string GenerateInvoiceNumber(DateOnly periodStart)
        {
            var n = ++_invoiceSeq;
            return $"INV-{periodStart:yyyyMM}-{n:D5}";
        }
    }
}
