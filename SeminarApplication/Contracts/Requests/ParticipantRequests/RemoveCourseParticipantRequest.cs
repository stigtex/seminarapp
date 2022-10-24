namespace SeminarApplication.Contracts.Requests.ParticipantRequests;

public class RemoveCourseParticipantRequest
{
    public int CourseId { get; init; }
    public int ParticipantId { get; init; }
}