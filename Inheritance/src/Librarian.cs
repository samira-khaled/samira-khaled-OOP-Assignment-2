
namespace LibrarySystem;

public class Librarian : Staff
{
    public Librarian(string personId,string fullName,string phoneNumber,DateTime hireDate,decimal monthlySalary)
        : base(personId,fullName,phoneNumber,hireDate,monthlySalary,0m)
    {
    }

    public decimal ProcessReturn(Loan loan, DateTime returnDate)
    {
        ArgumentNullException.ThrowIfNull(loan);

        loan.Return(returnDate);

        return loan.CalculateLateFee();
    }

    public void MarkItemLost(Loan loan)
    {
        ArgumentNullException.ThrowIfNull(loan);

        loan.MarkAsLost();
    }
}
