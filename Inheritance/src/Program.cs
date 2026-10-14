
namespace LibrarySystem;

public class Program
{
    public static void Main()
    {
        DateTime today = new DateTime(2026, 10, 1);
        DateTime hireDate = new DateTime(2024, 1, 1);

        Console.WriteLine("===== Library System Demo =====");

        // These lines MUST NOT compile:
        // Person person = new Person("P1", "Test", "01000000000");
        // Member member = new Member("M1", "Test", "01000000000", 3, 0m);
        // Staff staff = new Staff("S1", "Test", "01000000000", hireDate, 5000m, 0m);
        // LibraryItem item = new LibraryItem("I1", "Test", 10m, 7, 1m);

        StudentMember student = new StudentMember(
            "M1", "Ahmed Ali", "01011111111");

        PremiumMember premium = new PremiumMember(
            "M2", "Mona Hassan", "01022222222", 10m);

        // These lines MUST NOT compile:
        // student.FullName = "Another Name";
        // student.Loans.Add(someLoan);
        // book.IsOnLoan = true;

        Console.WriteLine("\n===== Item Types =====");

        List<LibraryItem> items = new List<LibraryItem>
        {
            new Book("B1", "Clean Code", 10m),
            new DVD("D1", "C# Fundamentals", 10m),
            new Magazine("MZ1", "Tech Monthly", 10m)
        };

        foreach (LibraryItem item in items)
        {
            Console.WriteLine(
                $"{item.Title}: Loan period = {item.LoanPeriodDays} days, " +
                $"Daily late fee = {item.GetDailyLateFee():0.00}");
        }

        Console.WriteLine("\n===== Withdrawn Item Test =====");

        HeadLibrarian head = new HeadLibrarian(
            "S1", "Sara Adel", "01033333333", hireDate, 10000m);

        Book withdrawnBook = new Book("B2", "Unavailable Book", 10m);

        head.WithdrawItem(withdrawnBook);

        try
        {
            student.BorrowItem(withdrawnBook, "L1", today);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Rejected: {ex.Message}");
        }

        head.RestoreItem(withdrawnBook);

        Console.WriteLine("\n===== Already-On-Loan Test =====");

        StudentMember firstBorrower = new StudentMember(
            "M3", "Omar Samy", "01044444444");

        StudentMember secondBorrower = new StudentMember(
            "M4", "Nour Tarek", "01055555555");

        Book sharedBook = new Book("B3", "OOP Basics", 10m);

        firstBorrower.BorrowItem(sharedBook, "L2", today);

        try
        {
            secondBorrower.BorrowItem(sharedBook, "L3", today);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Rejected: {ex.Message}");
        }

        Console.WriteLine("\n===== Student Loan Limit Test =====");

        student.BorrowItem(
            new Book("B4", "Book One", 10m), "L4", today);

        student.BorrowItem(
            new Book("B5", "Book Two", 10m), "L5", today);

        student.BorrowItem(
            new Book("B6", "Book Three", 10m), "L6", today);

        Console.WriteLine($"Active student loans: {student.Loans.Count}");

        try
        {
            student.BorrowItem(
                new Book("B7", "Book Four", 10m), "L7", today);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Rejected: {ex.Message}");
        }

        Console.WriteLine("\n===== Staff Polymorphism =====");

        List<Staff> staffMembers = new List<Staff>
        {
            new Librarian(
                "S2", "Ali Mostafa", "01066666666", hireDate, 6000m),

            head,

            new Shelver(
                "S3", "Mariam Hany", "01077777777",
                hireDate, 4500m, "Science")
        };

        foreach (Staff staff in staffMembers)
        {
            Console.WriteLine(
                $"{staff.FullName}: Monthly pay = " +
                $"{staff.CalculateMonthlyPay():0.00}");
        }

        Console.WriteLine("\n===== Premium Member Late Return =====");

        DVD dvd = new DVD("D2", "Advanced C#", 10m);

        Loan premiumLoan = premium.BorrowItem(
            dvd, "L8", today);

        DateTime returnDate = premiumLoan.DueDate.AddDays(5);

        Librarian librarian = new Librarian(
            "S4", "Hany Mahmoud", "01088888888",
            hireDate, 6000m);

        decimal lateFee = librarian.ProcessReturn(
            premiumLoan, returnDate);

        Console.WriteLine($"Borrow date: {premiumLoan.BorrowDate:yyyy-MM-dd}");
        Console.WriteLine($"Due date: {premiumLoan.DueDate:yyyy-MM-dd}");
        Console.WriteLine($"Return date: {premiumLoan.ReturnDate:yyyy-MM-dd}");
        Console.WriteLine($"Daily fee: {dvd.GetDailyLateFee():0.00}");
        Console.WriteLine($"Late fee after discount: {lateFee:0.00}");
        Console.WriteLine($"Premium reading points: {premium.ReadingPoints}");

        Console.WriteLine("\n===== Invalid Loan Transitions =====");

        try
        {
            premiumLoan.Return(returnDate);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Second return rejected: {ex.Message}");
        }

        try
        {
            premiumLoan.MarkAsLost();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Marking returned loan as lost rejected: {ex.Message}");
        }

        Console.WriteLine("\n===== Demo Finished =====");
    }
}
