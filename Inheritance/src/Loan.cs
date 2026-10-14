
namespace LibrarySystem;

public enum LoanStatus
{
    Borrowed,
    Returned,
    Lost
}

public class Loan
{
    public string LoanId { get; }
    public DateTime BorrowDate { get; }
    public DateTime DueDate { get; }
    public DateTime? ReturnDate { get; private set; }
    public LoanStatus Status { get; private set; }

    public Member Member { get; }
    public LibraryItem Item { get; }

    internal Loan(string loanId,Member member,LibraryItem item,DateTime borrowDate)
    {
        if (string.IsNullOrWhiteSpace(loanId))
            throw new ArgumentException("Loan ID cannot be empty.",nameof(loanId));

        ArgumentNullException.ThrowIfNull(member);
        ArgumentNullException.ThrowIfNull(item);

        if (item.IsWithdrawn)throw new InvalidOperationException("A withdrawn item cannot be borrowed.");

        if (item.IsOnLoan)throw new InvalidOperationException("This item is already on loan.");

        LoanId = loanId;
        Member = member;
        Item = item;
        BorrowDate = borrowDate;
        DueDate = borrowDate.AddDays(item.LoanPeriodDays);
        Status = LoanStatus.Borrowed;

        Item.MarkAsOnLoan();
    }

    public decimal CalculateLateFee()
    {
        if (ReturnDate is null ||
            ReturnDate.Value.Date <= DueDate.Date)
        {
            return 0m;
        }

        int daysLate = (ReturnDate.Value.Date - DueDate.Date).Days;

        decimal fee = daysLate * Item.GetDailyLateFee();

        return fee * (1 - Member.LateFeeDiscountPercent / 100m);
    }

    public void Return(DateTime returnDate)
    {
        if (Status != LoanStatus.Borrowed)
            throw new InvalidOperationException("Only borrowed loans can be returned.");

        if (returnDate < BorrowDate)
            throw new ArgumentException( "Return date cannot be before borrow date.", nameof(returnDate));

        ReturnDate = returnDate;
        Status = LoanStatus.Returned;

        Item.MarkAsReturned();

        if (Member is PremiumMember premiumMember)
        {
            premiumMember.AddReadingPointsForReturnedLoan();
        }
    }

    public void MarkAsLost()
    {
        if (Status != LoanStatus.Borrowed)
            throw new InvalidOperationException( "Only borrowed loans can be marked as lost.");

        Status = LoanStatus.Lost;
    }
}
