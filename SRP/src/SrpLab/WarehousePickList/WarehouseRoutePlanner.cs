using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.WarehousePickList
{
    public class WarehouseRoutePlanner
    {
        public IReadOnlyList<(string Aisle, int Bin, string Sku, int Qty)> PlanRoute(IEnumerable<(string Sku, string Aisle, int Bin, int QtyNeeded, int QtyOnHand)> lines)
        {
            // Path heuristic will change with warehouse layout tech.
            return lines
                .OrderBy(l => l.Aisle)
                .ThenBy(l => l.Bin)
                .Select(l => (l.Aisle, l.Bin, l.Sku, Math.Min(l.QtyNeeded, l.QtyOnHand)))
                .Where(x => x.Item4 > 0)
                .ToList();
        }
    }
}
