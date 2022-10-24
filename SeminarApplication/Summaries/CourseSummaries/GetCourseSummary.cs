using FastEndpoints;
using SeminarApplication.Contracts.Responses.CourseResponses;
using SeminarApplication.Endpoints.CourseEndpoints;

namespace SeminarApplication.Summaries.CourseSummaries;

public class GetCourseSummary : Summary<GetCourseEndpoint>
{
    public GetCourseSummary()
    {
        Summary = "Returns a single course by id";
        Description = "Returns a single course by id";
        Response<CourseResponse>(200, "Successfully found and returned the course");
        Response(404, "The course does not exist in the system");
    }
}