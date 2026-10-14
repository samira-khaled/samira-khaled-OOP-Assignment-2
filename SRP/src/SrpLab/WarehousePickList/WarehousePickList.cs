namespace SrpLab.WarehousePickList;

/// <summary>
/// Warehouse pick list: naive path order, stock allocation, and picker instruction prose.
/// </summary>
public sealed class WarehousePickList
{
    private readonly List<(string Sku, string Aisle, int Bin, int QtyNeeded, int QtyOnHand)> _lines = new(); 
    private readonly StockAllocator stockAllocator = new();
    private readonly WarehouseRoutePlanner warehouseRoutePlanner = new();
    private readonly PickerScriptBuilder pickerScriptBuilder = new();
    private readonly WmsXmlBatchBuilder wmsXmlBatchBuilder = new();

    public void AddNeed(string sku, string aisle, int bin, int qtyNeeded, int qtyOnHand)
    {
        _lines.Add((sku, aisle, bin, qtyNeeded, qtyOnHand));
    }

    public IReadOnlyList<(string Sku, int Allocated)> Allocate()
    {
        
        return stockAllocator.AllocateStock(_lines);
    }

    public IReadOnlyList<(string Aisle, int Bin, string Sku, int Qty)> WalkingOrder()
    {
     
        return warehouseRoutePlanner.PlanRoute(_lines);
    }

    public string PickerScript()
    {
        
        var steps = WalkingOrder();
     
        return pickerScriptBuilder.BuildScript(Allocate(), steps, _lines);
    }

    public string WmsXmlBatch(string batchId)
    {
        return wmsXmlBatchBuilder.BuildXmlBatch(batchId, Allocate(), _lines);
    }
}
