using FastEndpoints;
using SeminarApplication.Contracts.Responses;
using SeminarApplication.Contracts.Responses.SeminarResponses;
using SeminarApplication.Endpoints.SeminarEndpoints;

namespace SeminarApplication.Summaries.SeminarSummaries;

public class CreateSeminarSummary : Summary<CreateSeminarEndpoint>
{
    public CreateSeminarSummary()
    {
        Summary = "Creates a new seminar in the system";
        Description = "Creates a new seminar in the system";
        Response<SeminarResponse>(201, "Seminar was successfully created");
        Response<ValidationFailureResponse>(400, "The request did not pass validation checks");
    }
}