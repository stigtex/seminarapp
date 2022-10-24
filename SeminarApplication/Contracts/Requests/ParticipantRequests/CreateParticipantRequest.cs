namespace SeminarApplication.Contracts.Requests.ParticipantRequests;

public class CreateParticipantRequest
{
    public string FirstName { get; init; } = default!;
    public string LastName { get; init; } = default!;
    public string EmailAddress { get; init; } = default!;
}