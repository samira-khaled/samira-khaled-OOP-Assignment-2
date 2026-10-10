namespace SrpLab.CheckoutBasket;


/// <summary>
/// Online checkout basket: totals, coupon linguistics, gift-wrap copy, and a faux payment auth code.
/// </summary>
public sealed class CheckoutBasket
{
    private readonly CouponDiscountCalculator _couponCalculator = new();
    private readonly GiftMessageCard _giftMessageCard = new();
    private readonly PaymentAuthorizer _paymentAuthorizer = new();
    private readonly GiftWrapFeeCalculator _giftServices = new();
    private readonly List<(string Sku, decimal Price, int Qty)> _lines = new();
    private string? _couponRaw;
    private bool _giftWrap;

    public void AddLine(string sku, decimal price, int qty)
    {
        if (qty <= 0) throw new ArgumentOutOfRangeException(nameof(qty));
        _lines.Add((sku, price, qty));
    }

    public void ApplyCouponText(string? couponText) => _couponRaw = couponText;
    public void EnableGiftWrap() => _giftWrap = true;

    public decimal SubTotal() => _lines.Sum(l => l.Price * l.Qty);

    public decimal DiscountAmount()
    {

        return _couponCalculator.CalculateDiscount(_couponRaw,  SubTotal());
    
        
    }


    public decimal GrandTotal()
    {
        var total = SubTotal() - DiscountAmount();
        total += _giftServices.CalculateGiftWrapFee( _giftWrap);

        return Math.Max(0m, total);
    }


    public string GiftMessageCard(string fromName)
    {
        return _giftMessageCard.GiftMessage(fromName, _lines, GrandTotal());
    }

    public string AuthorizePaymentStub(string cardLast4)
    {
        return _paymentAuthorizer.AuthorizePaymentStub(cardLast4, GrandTotal(), _lines.Count);
    }
}
