using FastEndpoints;
using SeminarApplication.Contracts.Responses;
using SeminarApplication.Contracts.Responses.CourseResponses;
using SeminarApplication.Endpoints.CourseEndpoints;

namespace SeminarApplication.Summaries.CourseSummaries;

public class AddSeminarCourseSummary : Summary<AddSeminarCourseEndpoint>
{
    public AddSeminarCourseSummary()
    {
        Summary = "Adds a new course to a seminar in the system";
        Description = "Adds a new course to a seminar in the system";
        Response<SeminarCourseResponse>(201, "Course was successfully added to seminar");
        Response<ValidationFailureResponse>(400, "The request did not pass validation checks");
    }
}