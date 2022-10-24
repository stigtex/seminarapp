using FastEndpoints;
using SeminarApplication.Contracts.Responses;
using SeminarApplication.Contracts.Responses.CourseResponses;
using SeminarApplication.Endpoints.CourseEndpoints;

namespace SeminarApplication.Summaries.CourseSummaries;

public class CreateCourseSummary : Summary<CreateCourseEndpoint>
{
    public CreateCourseSummary()
    {
        Summary = "Creates a new course in the system";
        Description = "Creates a new course in the system";
        Response<CourseResponse>(201, "Course was successfully created");
        Response<ValidationFailureResponse>(400, "The request did not pass validation checks");
    }
}