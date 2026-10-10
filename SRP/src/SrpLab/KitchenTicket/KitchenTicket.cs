namespace SrpLab.KitchenTicket;

/// <summary>
/// Kitchen ticket: allergen scan from ingredients, cook ETA heuristics, and printed ticket layout.
/// </summary>
public sealed class KitchenTicket
{
    private readonly List<(string Item, List<string> Ingredients, int PrepMinutes)> _items = new();
    private readonly AllergenDetector allergenDetector=new();
    private readonly CookTimeEstimator cookTimeEstimator= new();
    private readonly ThermalTicketRenderer ticketPrinter = new();
    private readonly ExpoLaneSelector expoLaneSelector = new();

    public void AddItem(string item, IEnumerable<string> ingredients, int prepMinutes)
    {
        _items.Add((item, ingredients.Select(i => i.Trim().ToLowerInvariant()).ToList(), prepMinutes));
    }

    public IReadOnlyList<string> DetectAllergens()
    {
        return allergenDetector.ScanForAllergens(_items);
    }

    public int EstimatedReadyMinutes(int openStations)
    {
        // Kitchen ops model ≠ printing.
        
        return cookTimeEstimator.EstimateCookTime(_items, openStations, DetectAllergens());
    }

    public string RenderThermalTicket(int orderNumber)
    {
        return ticketPrinter.PrintThermalTicket(orderNumber, _items, DetectAllergens(), EstimatedReadyMinutes(2));
    }

    public string ExpoLaneHint()
    {
        return expoLaneSelector.SelectExpoLane(EstimatedReadyMinutes(2), DetectAllergens());
    }
}
