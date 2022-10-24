using FastEndpoints;
using SeminarApplication.Contracts.Responses.SeminarResponses;
using SeminarApplication.Endpoints.SeminarEndpoints;

namespace SeminarApplication.Summaries.SeminarSummaries;

public class GetSeminarSummary : Summary<GetSeminarEndpoint>
{
    public GetSeminarSummary()
    {
        Summary = "Returns a single seminar by id";
        Description = "Returns a single seminar by id";
        Response<SeminarResponse>(200, "Successfully found and returned the seminar");
        Response(404, "The seminar does not exist in the system");
    }
}