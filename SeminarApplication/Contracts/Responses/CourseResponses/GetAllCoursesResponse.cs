namespace SeminarApplication.Contracts.Responses.CourseResponses;

public class GetAllCoursesResponse
{
    public IEnumerable<CourseResponse> Courses { get; init; } = Enumerable.Empty<CourseResponse>();
}