namespace SeminarApplication.Contracts.Responses.ParticipantResponses;

public class GetAllParticipantResponse
{
    public IEnumerable<ParticipantResponse> Participants { get; init; }  = Enumerable.Empty<ParticipantResponse>();
}