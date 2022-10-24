namespace SeminarApplication.Contracts.Requests.SeminarRequests;

public class CreateSeminar
{
    public string SeminarName { get; init; } = default!;
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
}