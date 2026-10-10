namespace SrpLab.GradeBook;

/// <summary>
/// Grade book: aggregation, letter-band policy, and transcript export.
/// </summary>
public sealed class GradeBook
{
    private readonly Dictionary<string, List<decimal>> _scores = new(StringComparer.OrdinalIgnoreCase);
    private readonly GradeCalculator _gradeCalculator = new();
    private readonly GradePolicy _gradePolicy = new();
    private readonly TranscriptFormatter _transcriptExporter = new();
    private readonly GradeCsvExporter _csvExporter = new();


    public void Record(string studentId, decimal score)
    {
         _gradeCalculator.RecordScore(_scores, studentId, score);

    }

    public decimal Average(string studentId)
    {
        
        return _gradeCalculator.CalculateAverage(_scores, studentId);
    }

    public string Letter(string studentId)
    {
       
        return _gradePolicy.LetterGrade(Average(studentId));
    }

    public bool MeetsHonorRoll(string studentId)
    {
        
        return _gradePolicy.IsHonorRoll( Average(studentId));
    }

    public string TranscriptPlain(string studentId, string fullName)
    {
        
        return _transcriptExporter.ExportTranscript(studentId, fullName, Average(studentId), Letter(studentId), MeetsHonorRoll(studentId));
    }

    public string ExportCsv()
    {
        return _csvExporter.ExportCsvBuilder(_scores.Keys, Average, Letter, MeetsHonorRoll);
    }
}
