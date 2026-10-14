
namespace LibrarySystem;

public class StudentMember : Member
{
    public StudentMember(string personId,string fullName,string phoneNumber)
        : base(personId,fullName,phoneNumber,3,0m)
    {

    }
}
