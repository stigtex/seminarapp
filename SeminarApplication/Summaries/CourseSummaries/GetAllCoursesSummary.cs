using FastEndpoints;
using SeminarApplication.Contracts.Responses.CourseResponses;
using SeminarApplication.Endpoints.CourseEndpoints;

namespace SeminarApplication.Summaries.CourseSummaries;

public class GetAllCoursesSummary : Summary<GetAllCoursesEndpoint>
{
    public GetAllCoursesSummary()
    {
        Summary = "Returns all the courses in the system";
        Description = "Returns all the courses in the system";
        Response<GetAllCoursesResponse>(200, "All courses in the system are returned");
    }
}