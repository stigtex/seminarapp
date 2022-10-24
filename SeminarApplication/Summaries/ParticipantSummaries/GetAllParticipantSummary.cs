using FastEndpoints;
using SeminarApplication.Contracts.Responses.ParticipantResponses;
using SeminarApplication.Endpoints.ParticipantEndpoints;

namespace SeminarApplication.Summaries.ParticipantSummaries;

public class GetAllParticipantSummary : Summary<GetAllParticipantEndpoint>
{
    public GetAllParticipantSummary()
    {
        Summary = "Returns all the participant in the system";
        Description = "Returns all the participant in the system";
        Response<GetAllParticipantResponse>(200, "All participant in the system are returned");
    }
}