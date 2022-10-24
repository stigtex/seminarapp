namespace SeminarApplication.Contracts.Responses.ParticipantResponses;

public class ParticipantResponse
{
    public int Id { get; init; }
    public string FirstName { get; init; } = default!;
    public string LastName { get; init; } = default!;
    public string EmailAddress { get; init; } = default!;
}