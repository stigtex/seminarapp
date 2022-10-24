namespace SeminarApplication.Contracts.Requests.ParticipantRequests;

public class UpdateParticipantRequest
{
    public int Id { get; init; }
    public string FirstName { get; init; } = default!;
    public string LastName { get; init; } = default!;
    public string EmailAddress { get; init; } = default!;
}