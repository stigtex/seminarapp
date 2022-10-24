namespace SeminarApplication.Contracts.Responses.SeminarResponses;

public class SeminarResponse
{
    public int Id { get; init; }
    public string SeminarName { get; init; } = default!;
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
}