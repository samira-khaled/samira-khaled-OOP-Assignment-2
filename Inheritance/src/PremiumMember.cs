
namespace LibrarySystem;

public class PremiumMember : Member
{
    private int readingPoints;

    public int ReadingPoints => readingPoints;

    public PremiumMember(string personId, string fullName, string phoneNumber, decimal lateFeeDiscountPercent)
        : base(personId,fullName,phoneNumber,10,lateFeeDiscountPercent)
    {
        if (lateFeeDiscountPercent < 0 || lateFeeDiscountPercent > 100)
            throw new ArgumentException( "Discount must be between 0 and 100.", nameof(lateFeeDiscountPercent));
    }

    internal void AddReadingPointsForReturnedLoan()
    {
        readingPoints += 5;
    }
}
