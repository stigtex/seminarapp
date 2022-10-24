using FastEndpoints;
using SeminarApplication.Contracts.Responses;
using SeminarApplication.Contracts.Responses.SeminarResponses;
using SeminarApplication.Endpoints.SeminarEndpoints;

namespace SeminarApplication.Summaries.SeminarSummaries;

public class UpdateSeminarSummary : Summary<UpdateSeminarEndpoint>
{
    public UpdateSeminarSummary()
    {
        Summary = "Updates an existing seminar in the system";
        Description = "Updates an existing seminar in the system";
        Response<SeminarResponse>(201, "Seminar was successfully updated");
        Response<ValidationFailureResponse>(400, "The request did not pass validation checks");
    }
}