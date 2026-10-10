namespace SrpLab.LoanDesk;

/// <summary>
/// Loan desk: eligibility arithmetic, required-document lists, and rejection letter prose.
/// </summary>
public sealed class LoanDesk
{
    public decimal RequestedAmount { get; }
    public int CreditScore { get; }
    public int EmploymentMonths { get; }
    public bool HasCollateral { get; }
    private readonly LoanAssessment loanAssessment = new();
    private readonly RequiredDocumentsProvider documentRequirements = new();
    private readonly LoanDecisionLetterBuilder letterBuilder = new();
    private readonly UnderwriterCsvExporter csvRowBuilder = new();
    public LoanDesk(decimal requestedAmount, int creditScore, int employmentMonths, bool hasCollateral)
    {
        RequestedAmount = requestedAmount;
        CreditScore = creditScore;
        EmploymentMonths = employmentMonths;
        HasCollateral = hasCollateral;
    }

    public decimal RiskScore()
    {
        // Risk model will change with risk committee — not with letter templates.
        return loanAssessment.CalculateRiskScore(CreditScore, EmploymentMonths, RequestedAmount, HasCollateral);
    }

    public bool IsEligible() => loanAssessment.IsEligible(CreditScore, EmploymentMonths, RequestedAmount, HasCollateral);

    public IReadOnlyList<string> RequiredDocuments()
    {
        return documentRequirements.GetRequiredDocuments(EmploymentMonths, RequestedAmount, HasCollateral, IsEligible());

    }

    public string DecisionLetter(string applicantName)
    {
        return letterBuilder.BuildDecisionLetter(applicantName, RequestedAmount, RiskScore(), IsEligible(), RequiredDocuments());
    }

    public string UnderwriterCsvRow(string applicationId)
    {
        return csvRowBuilder.BuildCsvRow(applicationId,CreditScore, EmploymentMonths, HasCollateral, RiskScore(), IsEligible());
    }
}
