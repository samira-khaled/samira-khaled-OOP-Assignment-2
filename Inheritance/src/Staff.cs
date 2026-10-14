
namespace LibrarySystem;

public class Staff : Person
{
    private readonly decimal responsibilityAllowance;

    public DateTime HireDate { get; }
    public decimal MonthlySalary { get; private set; }

    protected Staff(string personId,string fullName,string phoneNumber,DateTime hireDate,decimal monthlySalary,decimal responsibilityAllowance)
        : base(personId, fullName, phoneNumber)
    {
        if (monthlySalary <= 0)
            throw new ArgumentException("Monthly salary must be greater than zero.",nameof(monthlySalary));

        if (responsibilityAllowance < 0)throw new ArgumentException("Responsibility allowance cannot be negative.",nameof(responsibilityAllowance));

        HireDate = hireDate;
        MonthlySalary = monthlySalary;
        this.responsibilityAllowance = responsibilityAllowance;
    }

    public void GiveRaise(decimal percentage)
    {
        if (percentage <= 0)throw new ArgumentException("Raise percentage must be greater than zero.",nameof(percentage));

        MonthlySalary += MonthlySalary * percentage / 100m;
    }

    public decimal CalculateMonthlyPay()
    {
        return MonthlySalary + responsibilityAllowance;
    }
}
