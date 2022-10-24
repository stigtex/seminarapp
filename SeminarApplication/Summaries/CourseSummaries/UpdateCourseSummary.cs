using FastEndpoints;
using SeminarApplication.Contracts.Responses;
using SeminarApplication.Contracts.Responses.CourseResponses;
using SeminarApplication.Endpoints.CourseEndpoints;

namespace SeminarApplication.Summaries.CourseSummaries;

public class UpdateCourseSummary : Summary<UpdateCourseEndpoint>
{
    public UpdateCourseSummary()
    {
        Summary = "Updates an existing course in the system";
        Description = "Updates an existing course in the system";
        Response<CourseResponse>(201, "Course was successfully updated");
        Response<ValidationFailureResponse>(400, "The request did not pass validation checks");
    }
}