namespace SeminarApplication.Contracts.Requests.ParticipantRequests;

public class AddCourseParticipantRequest
{
    public int CourseId { get; init; }
    public int ParticipantId { get; init; }
}