using FastEndpoints;
using SeminarApplication.Contracts.Responses.CourseResponses;
using SeminarApplication.Endpoints.CourseEndpoints;

namespace SeminarApplication.Summaries.CourseSummaries;

public class GetAllSeminarCoursesSummary : Summary<GetAllSeminarCoursesEndpoint>
{
    public GetAllSeminarCoursesSummary()
    {
        Summary = "Gets all courses for a seminar in the system";
        Description = "Gets all courses for a seminar in the system";
        Response<GetAllSeminarCoursesResponse>(201, "All courses for a seminar in the system are returned");
    }
}