namespace SeminarApplication.Contracts.Requests.CourseRequests;

public class CreateCourseRequest
{
    public string CourseName { get; init; } = default!;
    public string InstructorFirstName { get; init; } = default!;
    public string InstructorLastName { get; init; } = default!;
    public string RoomName { get; init; } = default!;
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
}