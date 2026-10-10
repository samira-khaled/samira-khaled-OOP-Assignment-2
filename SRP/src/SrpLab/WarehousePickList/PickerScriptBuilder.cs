using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.WarehousePickList
{
    

    public class PickerScriptBuilder
    {
        public string BuildScript(
            IEnumerable<(string Sku, int Allocated)> allocatedLines,
            IEnumerable<(string Aisle, int Bin, string Sku, int Qty)> steps,
            IEnumerable<(string Sku, string Aisle, int Bin, int QtyNeeded, int QtyOnHand)> lines)
        {
            var scriptSteps = steps.Select((s, i) =>
                $"{i + 1}. Go aisle {s.Aisle} bin {s.Bin}: pick {s.Qty} × {s.Sku}");

            var shortfalls = allocatedLines.Where(a =>
            {
                var need = lines.First(l => l.Sku == a.Sku).QtyNeeded;
                return a.Allocated < need;
            });

            var warn = shortfalls.Any()
                ? "SHORTAGES: " + string.Join(", ", shortfalls.Select(s => s.Sku))
                : "SHORTAGES: none";

            return string.Join('\n', scriptSteps) + "\n" + warn;
        }
    }
}
