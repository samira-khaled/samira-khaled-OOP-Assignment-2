namespace SrpLab;

/// <summary>
/// Hospital ward board: tracks beds, computes acuity scores, drafts nurse handoff notes,
/// and decides which pager code to fire. Looks like "one ward concern" — it is not.
/// </summary>
public sealed class WardBoard
{
    private readonly Dictionary<int, string> _bedPatient = new();
    private readonly Dictionary<int, int> _vitalsScore = new();
    private readonly CensusCsvExporter _censusCsvExporter = new();
    private readonly HandoffNoteBuilder _handoffNoteBuilder = new();
    private readonly AcuityScorer _acuityScorer = new();
    private readonly PagerService _pagerService = new();

    public void AssignBed(int bed, string patientId, int heartRate, int spo2)
    {
        if (bed <= 0) throw new ArgumentOutOfRangeException(nameof(bed));
        if (string.IsNullOrWhiteSpace(patientId)) throw new ArgumentException("patient required");

        _bedPatient[bed] = patientId.Trim().ToUpperInvariant();
        _vitalsScore[bed] = _acuityScorer.ScoreAcuity(heartRate, spo2);

        _pagerService.CheckAndLogPager(bed, _vitalsScore[bed]);
    }
    public string BuildHandoffNote(int bed)
    {
        if (!_bedPatient.TryGetValue(bed, out var patient))
            return $"Bed {bed}: empty";

        var acuity = _vitalsScore[bed];

        return _handoffNoteBuilder.BuildHandoffNote(
            bed, patient, acuity);
    }
    public IReadOnlyList<string> DrainPagerLog()
    {
        return _pagerService.DrainPagerLog();
    }
    public string ExportCensusCsv()
    {
        return _censusCsvExporter.ExportCensusCsv(_bedPatient, _vitalsScore);
    }
}