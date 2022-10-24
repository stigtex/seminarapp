namespace SeminarApplication.Contracts.Requests.SeminarRequests;

public class UpdateSeminarRequest
{
    public int Id { get; init; }
    public string SeminarName { get; init; } = default!;
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
}