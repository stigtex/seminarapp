namespace SeminarApplication.Contracts.Responses.CourseResponses;

public class GetAllSeminarCoursesResponse
{
    public IEnumerable<CourseResponse> Courses { get; init; } = Enumerable.Empty<CourseResponse>();
}