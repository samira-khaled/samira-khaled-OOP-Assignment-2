using SrpLab.SubscriptionBilling;



/// <summary>
/// Subscription billing: proration math, invoice number minting, and dunning email bodies.
/// </summary>
public sealed class SubscriptionBilling
{


    public string CustomerId { get; }
    public decimal MonthlyPrice { get; }
    public DateOnly PeriodStart { get; }
    public DateOnly PeriodEnd { get; }
    public int FailedPayments { get; private set; }



    private readonly ProrationCalculator _prorationCalculator = new();
    private readonly InvoiceNumberGenerator _invoiceNumberGenerator = new();
    private readonly DunningEmailBuilder _dunningEmailBuilder = new();
    private readonly LedgerJournalFormatter _ledgerJournalLineBuilder = new();

    public SubscriptionBilling(string customerId, decimal monthlyPrice, DateOnly periodStart, DateOnly periodEnd)
    {
        CustomerId = customerId;
        MonthlyPrice = monthlyPrice;
        PeriodStart = periodStart;
        PeriodEnd = periodEnd;
    }

    public decimal Prorate(DateOnly activeFrom)
    {
        // Finance calendar rules change independently of email copy.
     return _prorationCalculator.CalculateProratedAmount(MonthlyPrice, PeriodStart, PeriodEnd, activeFrom);
    }

    public string NextInvoiceNumber()
    {
        
        return _invoiceNumberGenerator.GenerateInvoiceNumber(PeriodStart);
    }

    public void RegisterFailedPayment() => FailedPayments++;

    public string DunningEmail(string customerName, DateOnly asOf)
    {
        // Collections tone & legal boilerplate ≠ proration formula.
        var amount = Prorate(PeriodStart);
        var invoice = NextInvoiceNumber(); // side-effect while composing mail — nasty on purpose
        return _dunningEmailBuilder.BuildDunningEmail(customerName, asOf, FailedPayments, amount, invoice);
    }

    public string LedgerJournalLine(DateOnly activeFrom)
    {

        var invoice = NextInvoiceNumber();
        var amount = Prorate(activeFrom);
        return _ledgerJournalLineBuilder.FormatLedgerJournalLine(CustomerId, invoice, amount);
    }
}
