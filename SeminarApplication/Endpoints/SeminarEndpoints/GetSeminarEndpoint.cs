using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using SeminarApplication.Contracts.Requests.SeminarRequests;
using SeminarApplication.Contracts.Responses.SeminarResponses;
using SeminarApplication.Mapping;
using SeminarApplication.Services;

namespace SeminarApplication.Endpoints.SeminarEndpoints;

[HttpGet("seminars/{id:int}"), AllowAnonymous]
public class GetSeminarEndpoint  : Endpoint<GetSeminar, SeminarResponse>
{
    private readonly ISeminarService _seminarService;
    
    public GetSeminarEndpoint(ISeminarService seminarService)
    {
        _seminarService = seminarService;
    }
    
    public override async Task HandleAsync(GetSeminar req, CancellationToken ct)
    {
        var seminar = await _seminarService.GetAsync(req.Id);

        if (seminar is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var seminarResponse = seminar.ToSeminarResponse();
        await SendOkAsync(seminarResponse, ct);
    }
}