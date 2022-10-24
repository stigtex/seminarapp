using FastEndpoints;
using SeminarApplication.Endpoints.ParticipantEndpoints;

namespace SeminarApplication.Summaries.ParticipantSummaries;

public class DeleteParticipantSummary : Summary<DeleteParticipantEndpoint>
{
    public DeleteParticipantSummary()
    {
        Summary = "Deletes a participant the system";
        Description = "Deletes a participant the system";
        Response(204, "The participant was deleted successfully");
        Response(404, "The participant was not found in the system");
    }
}