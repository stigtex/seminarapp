namespace SeminarApplication.Contracts.Requests.ParticipantRequests;

public class CreateParticipant
{
    public string FirstName { get; init; } = default!;
    public string LastName { get; init; } = default!;
    public string EmailAddress { get; init; } = default!;
}