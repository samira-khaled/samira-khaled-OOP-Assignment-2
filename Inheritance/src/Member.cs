
namespace LibrarySystem;

public class Member : Person
{
    private readonly List<Loan> loanHistory = new();

    public IReadOnlyList<Loan> Loans => loanHistory.AsReadOnly();

    public int MaxLoans { get; }

    public decimal LateFeeDiscountPercent { get; }

    protected Member(string personId,string fullName,string phoneNumber,int maxLoans,decimal lateFeeDiscountPercent)
        : base(personId, fullName, phoneNumber)
    {
        if (maxLoans <= 0)
            throw new ArgumentException("Maximum loans must be positive.",nameof(maxLoans));

        if (lateFeeDiscountPercent < 0 || lateFeeDiscountPercent > 100)
            throw new ArgumentException("Discount must be between 0 and 100.",nameof(lateFeeDiscountPercent));

        MaxLoans = maxLoans;
        LateFeeDiscountPercent = lateFeeDiscountPercent;
    }

    public Loan BorrowItem(LibraryItem item,string loanId,DateTime borrowDate)
    {
        int activeLoans = 0;

        foreach (Loan loan in loanHistory)
        {
            if (loan.Status == LoanStatus.Borrowed)
            {
                activeLoans++;
            }
        }

        if (activeLoans >= MaxLoans)
        {
            throw new InvalidOperationException("Member has reached the maximum number of active loans.");
        }

        Loan newLoan = new Loan(loanId, this, item, borrowDate);

        loanHistory.Add(newLoan);

        return newLoan;
    }
}