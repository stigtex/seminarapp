using FastEndpoints;
using SeminarApplication.Contracts.Responses;
using SeminarApplication.Contracts.Responses.ParticipantResponses;
using SeminarApplication.Endpoints.ParticipantEndpoints;

namespace SeminarApplication.Summaries.ParticipantSummaries;

public class CreateParticipantSummary : Summary<CreateParticipantEndpoint>
{
    public CreateParticipantSummary()
    {
        Summary = "Creates a new participant in the system";
        Description = "Creates a new participant in the system";
        Response<ParticipantResponse>(201, "Participant was successfully created");
        Response<ValidationFailureResponse>(400, "The request did not pass validation checks");
    }
}