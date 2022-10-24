using FastEndpoints;
using SeminarApplication.Contracts.Responses.ParticipantResponses;
using SeminarApplication.Endpoints.ParticipantEndpoints;

namespace SeminarApplication.Summaries.ParticipantSummaries;

public class GetParticipantSummary : Summary<GetParticipantEndpoint>
{
    public GetParticipantSummary()
    {
        Summary = "Returns a single participant by id";
        Description = "Returns a single participant by id";
        Response<ParticipantResponse>(200, "Successfully found and returned the participant");
        Response(404, "The participant does not exist in the system");
    }
}