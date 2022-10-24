using FastEndpoints;
using SeminarApplication.Endpoints.SeminarEndpoints;

namespace SeminarApplication.Summaries.SeminarSummaries;

public class DeleteSeminarSummary : Summary<DeleteSeminarEndpoint>
{
    public DeleteSeminarSummary()
    {
        Summary = "Deletes a seminar the system";
        Description = "Deletes a seminar the system";
        Response(204, "The seminar was deleted successfully");
        Response(404, "The seminar was not found in the system");
    }
}