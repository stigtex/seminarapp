namespace SeminarApplication.Contracts.Responses.SeminarResponses;

public class GetAllSeminarsResponse
{
    public IEnumerable<SeminarResponse> Seminars { get; init; } = Enumerable.Empty<SeminarResponse>();
}