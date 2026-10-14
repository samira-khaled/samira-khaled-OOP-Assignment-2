using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.CheckoutBasket
{
    public class GiftMessageCard
    {
        public string GiftMessage(string fromName, List<(string Sku, decimal Price, int Qty)> lines, decimal grandTotal)
        {
            // Customer-facing copy will change with marketing, not with totals.
            var items = string.Join(", ", lines.Select(l => l.Sku));
            return $"Dear friend,\nA gift from {fromName} awaits ({items}).\nTotal surprise value: {grandTotal:C}\n";
        }

    }
}
