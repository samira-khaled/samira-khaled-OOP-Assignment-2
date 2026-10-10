using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.WarehousePickList
{
    public class WmsXmlBatchBuilder
    {
        public string BuildXmlBatch(string batchId, IEnumerable<(string Sku, int Allocated)> allocatedLines, IEnumerable<(string Sku, string Aisle, int Bin, int QtyNeeded, int QtyOnHand)> lines)
        {
            var parts = allocatedLines.Select(a => $"<line sku=\"{a.Sku}\" qty=\"{a.Allocated}\" />");
            return $"<batch id=\"{batchId}\">{string.Join("", parts)}</batch>";
        }
    }
}
