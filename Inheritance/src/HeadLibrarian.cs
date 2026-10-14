
namespace LibrarySystem;

public class HeadLibrarian : Staff
{
    public HeadLibrarian(string personId,string fullName,string phoneNumber,DateTime hireDate,decimal monthlySalary)
        : base(personId,fullName,phoneNumber,hireDate,monthlySalary,400m)
    {
    }

    public void ChangeLateFee(LibraryItem item, decimal newFee)
    {
        ArgumentNullException.ThrowIfNull(item);
        item.ChangeBaseLateFee(newFee);
    }

    public void WithdrawItem(LibraryItem item)
    {
        ArgumentNullException.ThrowIfNull(item);
        item.Withdraw();
    }

    public void RestoreItem(LibraryItem item)
    {
        ArgumentNullException.ThrowIfNull(item);
        item.Restore();
    }
}
