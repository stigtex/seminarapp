using FastEndpoints;
using SeminarApplication.Contracts.Responses;
using SeminarApplication.Contracts.Responses.ParticipantResponses;
using SeminarApplication.Endpoints.ParticipantEndpoints;

namespace SeminarApplication.Summaries.ParticipantSummaries;

public class AddCourseParticipantSummary : Summary<AddCourseParticipantEndpoint>
{
    public AddCourseParticipantSummary()
    {
        Summary = "Adds a new participant to a course in the system";
        Description = "Adds a new participant to a course in the system";
        Response<CourseParticipantResponse>(201, "Participant was successfully added to course");
        Response<ValidationFailureResponse>(400, "The request did not pass validation checks");
    }
}