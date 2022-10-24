using FastEndpoints;
using SeminarApplication.Contracts.Responses;
using SeminarApplication.Contracts.Responses.CourseResponses;
using SeminarApplication.Endpoints.CourseEndpoints;

namespace SeminarApplication.Summaries.CourseSummaries;

public class RemoveSeminarCourseSummary : Summary<RemoveSeminarCourseEndpoint>
{
    public RemoveSeminarCourseSummary()
    {
        Summary = "Removes a course from a seminar in the system";
        Description = "Removes a course from a seminar in the system";
        Response<SeminarCourseResponse>(201, "Course was removed from seminar successfully");
        Response<ValidationFailureResponse>(400, "The course connected to the seminar was not found in the system");
    }
}