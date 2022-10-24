namespace SeminarApplication.Contracts.Requests.SeminarRequests;

public class CreateSeminarRequest
{
    public string SeminarName { get; init; } = default!;
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
}