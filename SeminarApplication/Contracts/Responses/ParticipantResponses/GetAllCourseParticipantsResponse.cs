namespace SeminarApplication.Contracts.Responses.ParticipantResponses;

public class GetAllCourseParticipantsResponse
{
    public IEnumerable<ParticipantResponse> Participants { get; init; }  = Enumerable.Empty<ParticipantResponse>();
}