using FastEndpoints;
using SeminarApplication.Contracts.Responses.SeminarResponses;
using SeminarApplication.Endpoints.SeminarEndpoints;

namespace SeminarApplication.Summaries.SeminarSummaries;

public class GetAllSeminarsSummary  : Summary<GetAllSeminarsEndpoint>
{
    public GetAllSeminarsSummary()
    {
        Summary = "Returns all the seminars in the system";
        Description = "Returns all the seminars in the system";
        Response<GetAllSeminarsResponse>(200, "All seminars in the system are returned");
    }
}