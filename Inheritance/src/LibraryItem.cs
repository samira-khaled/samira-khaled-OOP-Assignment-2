
namespace LibrarySystem;

public class LibraryItem
{
    private bool isOnLoan;
    private decimal lateFeeMultiplier;

    public string CatalogNumber { get; }
    public string Title { get; }

    public decimal BaseLateFee { get; private set; }
    public bool IsWithdrawn { get; private set; }
    public bool IsOnLoan => isOnLoan;

    public int LoanPeriodDays { get; }

    protected LibraryItem(
        string catalogNumber,
        string title,
        decimal baseLateFee,
        int loanPeriodDays,
        decimal lateFeeMultiplier)
    {
        if (string.IsNullOrWhiteSpace(catalogNumber))
            throw new ArgumentException(
                "Catalog number cannot be empty.", nameof(catalogNumber));

        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException(
                "Title cannot be empty.", nameof(title));

        if (baseLateFee <= 0)
            throw new ArgumentException(
                "Base late fee must be greater than zero.", nameof(baseLateFee));

        if (loanPeriodDays <= 0)
            throw new ArgumentException(
                "Loan period must be greater than zero.", nameof(loanPeriodDays));

        if (lateFeeMultiplier <= 0)
            throw new ArgumentException(
                "Late fee multiplier must be greater than zero.", nameof(lateFeeMultiplier));

        CatalogNumber = catalogNumber;
        Title = title;
        BaseLateFee = baseLateFee;
        LoanPeriodDays = loanPeriodDays;
        this.lateFeeMultiplier = lateFeeMultiplier;
    }

    public decimal GetDailyLateFee()
    {
        return BaseLateFee * lateFeeMultiplier;
    }

    public void ChangeBaseLateFee(decimal newFee)
    {
        if (newFee <= 0)
            throw new ArgumentException(
                "New late fee must be greater than zero.", nameof(newFee));

        BaseLateFee = newFee;
    }

    public void Withdraw()
    {
        if (isOnLoan)
            throw new InvalidOperationException(
                "An item on loan cannot be withdrawn.");

        IsWithdrawn = true;
    }

    public void Restore()
    {
        IsWithdrawn = false;
    }

    public void MarkAsOnLoan()
    {
        if (IsWithdrawn)
            throw new InvalidOperationException(
                "A withdrawn item cannot be borrowed.");

        if (isOnLoan)
            throw new InvalidOperationException(
                "This item is already on loan.");

        isOnLoan = true;
    }

    public void MarkAsReturned()
    {
        if (!isOnLoan)
            throw new InvalidOperationException(
                "This item is not currently on loan.");

        isOnLoan = false;
    }
}
