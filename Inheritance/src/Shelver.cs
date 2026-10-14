
namespace LibrarySystem;

public class Shelver : Staff
{
    public string Section { get; private set; }

    public Shelver(string personId,string fullName,string phoneNumber,DateTime hireDate,decimal monthlySalary,string section)
        : base(personId,fullName,phoneNumber,hireDate,monthlySalary,0m)
    {
        if (string.IsNullOrWhiteSpace(section))
            throw new ArgumentException("Section cannot be empty.", nameof(section));
            Section = section;
    }

    public void Reassign(string section)
    {
        if (string.IsNullOrWhiteSpace(section))
            throw new ArgumentException("Section cannot be empty.", nameof(section));

        Section = section;
    }
}
