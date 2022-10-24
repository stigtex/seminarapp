using FastEndpoints;
using SeminarApplication.Contracts.Responses;
using SeminarApplication.Contracts.Responses.CourseResponses;
using SeminarApplication.Endpoints.ParticipantEndpoints;

namespace SeminarApplication.Summaries.ParticipantSummaries;

public class RemoveCourseParticipantSummary : Summary<RemoveCourseParticipantEndpoint>
{
    public RemoveCourseParticipantSummary()
    {
        Summary = "Removes a participant from a course in the system";
        Description = "Removes a participant from a course in the system";
        Response<SeminarCourseResponse>(201, "Participant was removed from course successfully");
        Response<ValidationFailureResponse>(400, "The participant connected to the course was not found in the system");
    }
}