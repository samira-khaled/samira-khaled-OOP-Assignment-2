
namespace LibrarySystem;

public class Person
{
    public string PersonId { get; }
    public string FullName { get; }
    public string PhoneNumber { get; }

    protected Person(string personId, string fullName, string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(personId))
            throw new ArgumentException("Person ID cannot be empty.", nameof(personId));

        if (string.IsNullOrWhiteSpace(fullName))
            throw new ArgumentException("Full name cannot be empty.", nameof(fullName));

        if (string.IsNullOrWhiteSpace(phoneNumber))
            throw new ArgumentException("Phone number cannot be empty.", nameof(phoneNumber));

        PersonId = personId;
        FullName = fullName;
        PhoneNumber = phoneNumber;
    }
}
