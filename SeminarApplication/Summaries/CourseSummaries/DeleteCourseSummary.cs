using FastEndpoints;
using SeminarApplication.Endpoints.CourseEndpoints;

namespace SeminarApplication.Summaries.CourseSummaries;

public class DeleteCourseSummary : Summary<DeleteCourseEndpoint>
{
    public DeleteCourseSummary()
    {
        Summary = "Deletes a course the system";
        Description = "Deletes a course the system";
        Response(204, "The course was deleted successfully");
        Response(404, "The course was not found in the system");
    }
}