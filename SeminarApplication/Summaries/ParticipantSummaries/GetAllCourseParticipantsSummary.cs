using FastEndpoints;
using SeminarApplication.Contracts.Responses.ParticipantResponses;
using SeminarApplication.Endpoints.ParticipantEndpoints;

namespace SeminarApplication.Summaries.ParticipantSummaries;

public class GetAllCourseParticipantsSummary : Summary<GetAllCourseParticipantsEndpoint>
{
    public GetAllCourseParticipantsSummary()
    {
        Summary = "Gets all participants for a course in the system";
        Description = "Gets all participants for a course in the system";
        Response<GetAllCourseParticipantsResponse>(201, "All participants for a course in the system are returned");
    }
}