namespace SeminarApplication.Contracts.Requests.CourseRequests;

public class RemoveSeminarCourseRequest
{
    public int SeminarId { get; init; }
    public int CourseId { get; init; }
}