
using SrpLab.SupportTicket;

namespace SrpLab.SupportTicket;

/// <summary>
/// Support ticket: SLA clocks, NLP-ish priority from free text, and public reply templates.
/// </summary>
public sealed class SupportTicket
{
    public string Id { get; }
    public string Subject { get; private set; }
    public string Body { get; private set; }
    public DateTimeOffset OpenedAt { get; }
    public string Priority { get; private set; } = "P3";
    private readonly PriorityAnalyzer _PriorityAnalyzer = new();
    private readonly TicketMessageBuilder _TicketMessageBuilder = new();
    private readonly SLA _SLA = new();

    public SupportTicket(string id, string subject, string body, DateTimeOffset openedAt)
    {
        Id = id;
        Subject = subject;
        Body = body;
        OpenedAt = openedAt;
        RecalculatePriorityFromText();
    }

    public void AppendCustomerMessage(string text)
    {
        Body += "\n---\n" + text;
        RecalculatePriorityFromText();
    }

    public void RecalculatePriorityFromText()
    {
        _PriorityAnalyzer.CalculatePriority(Subject,Body,out var priority);

        Priority = priority;
    }

    public DateTimeOffset SlaDeadline()
    {
        
        return _SLA.Sla(Priority, OpenedAt);
    }

    public bool IsSlaBreached(DateTimeOffset now)
    {
        return _SLA.IsBreached(now, Priority, OpenedAt);
    }
    public string DraftPublicReply(string agentName)
    {
        // Tone/templates owned by CX — not by SLA engineering.
        return _TicketMessageBuilder.BuildPublicReply(agentName, Id, Priority, SlaDeadline());
    }

    public string InternalEscalationBlurb()
    {
        return _TicketMessageBuilder.BuildInternalEscalationBlurb(Id, Priority, SlaDeadline());
    }
}
