using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.CheckoutBasket
{
    public class PaymentAuthorizer
    {
        public string AuthorizePaymentStub(string cardLast4, decimal grandTotal, int lineCount)
        {
            // Pretends to talk to a gateway — auth scheme changes independently of cart rules.
            var payload = $"{grandTotal:0.00}|{cardLast4}|{lineCount}";
            var hash = payload.GetHashCode();
            return $"AUTH-{Math.Abs(hash):X8}";
        }
    }
}
