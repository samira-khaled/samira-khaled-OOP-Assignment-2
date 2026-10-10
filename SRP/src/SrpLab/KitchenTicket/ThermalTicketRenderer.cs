using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.KitchenTicket
{
    public class ThermalTicketRenderer
    {
        public string PrintThermalTicket(int orderNumber, IEnumerable<(string Item, List<string> Ingredients, int PrepMinutes)> items, IEnumerable<string> allergens, int estimatedReadyMinutes)
        {
            // Hardware/formatting concerns — width, separators — change with printer vendor.
            var width = 32;
            var line = new string('=', width);
            var body = string.Join('\n', items.Select(i => $"* {i.Item.ToUpperInvariant()} ({i.PrepMinutes}m)"));
            var allergyLine = allergens.Count() == 0 ? "ALLERGENS: none" : "ALLERGENS: " + string.Join(",", allergens);
            return $"{line}\nORDER #{orderNumber}\nETA {estimatedReadyMinutes} MIN\n{body}\n{allergyLine}\n{line}\n";
        }
    }
}
