using FastEndpoints;
using SeminarApplication.Contracts.Responses;
using SeminarApplication.Contracts.Responses.ParticipantResponses;
using SeminarApplication.Endpoints.ParticipantEndpoints;

namespace SeminarApplication.Summaries.ParticipantSummaries;

public class UpdateParticipantSummary : Summary<UpdateParticipantEndpoint>
{
    public UpdateParticipantSummary()
    {
        Summary = "Updates an existing participant in the system";
        Description = "Updates an existing participant in the system";
        Response<ParticipantResponse>(201, "Participant was successfully updated");
        Response<ValidationFailureResponse>(400, "The request did not pass validation checks");
    }
}