using SrpLab.CourseEnrollmentDesk;


/// <summary>
/// Course enrollment: capacity, waitlist math, welcome-packet markdown, and invoice lines.
/// </summary>
public sealed class CourseEnrollmentDesk
{
    
    public int Capacity { get; }
    public decimal Tuition { get; }
    public string CourseCode { get; }
    private readonly WelcomePacketBuilder _welcomePacketTemplate = new();
    private readonly EnrollmentManager _enrollmentManager;
    private readonly TuitionInvoiceBuilder tuitionInvoiceBuilder = new();

    public CourseEnrollmentDesk(string courseCode, int capacity, decimal tuition)
    {
        CourseCode = courseCode;
        Capacity = capacity;
        Tuition = tuition;
        _enrollmentManager=new EnrollmentManager(capacity);
    }

    public string Register(string studentEmail)
    {
        return _enrollmentManager.RegisterStudent(studentEmail);
    }

    public int WaitlistPosition(string studentEmail)
    {
      
        return _enrollmentManager.WaitlistPosition(studentEmail);
        
    }

    public string WelcomePacketMarkdown(string studentEmail, string studentName)
    {
        var status = _enrollmentManager.IsSeated(studentEmail) ? "confirmed seat": $"waitlist #{WaitlistPosition(studentEmail)}";

        return _welcomePacketTemplate.BuildWelcomePacket(studentName, CourseCode, status);
    }

    public string TuitionInvoiceLine(string studentEmail)
    {
        // Finance formatting / tax later — separate from enrollment capacity.
        return tuitionInvoiceBuilder.BuildInvoiceLine( _enrollmentManager.IsSeated(studentEmail), CourseCode, Tuition);
    }

    public void PromoteFromWaitlist(int seats)
    {
        // Operational promotion policy mixed with messaging responsibilities above.
        _enrollmentManager.PromoteFromWaitlist(seats);
    }
}
