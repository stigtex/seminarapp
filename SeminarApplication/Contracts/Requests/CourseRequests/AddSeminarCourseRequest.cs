namespace SeminarApplication.Contracts.Requests.CourseRequests;

public class AddSeminarCourseRequest
{
    public int SeminarId { get; init; }
    public int CourseId { get; init; }
}