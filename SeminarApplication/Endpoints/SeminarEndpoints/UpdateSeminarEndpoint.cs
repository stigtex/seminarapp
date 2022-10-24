using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using SeminarApplication.Contracts.Requests.SeminarRequests;
using SeminarApplication.Contracts.Responses.SeminarResponses;
using SeminarApplication.Mapping;
using SeminarApplication.Services;

namespace SeminarApplication.Endpoints.SeminarEndpoints;

[HttpPut("seminars/{id:int}"), AllowAnonymous]
public class UpdateSeminarEndpoint  : Endpoint<UpdateSeminar, SeminarResponse>
{
    private readonly ISeminarService _seminarService;
    
    public UpdateSeminarEndpoint(ISeminarService seminarService)
    {
        _seminarService = seminarService;
    }
    
    public override async Task HandleAsync(UpdateSeminar req, CancellationToken ct)
    {
        var existingSeminar = await _seminarService.GetAsync(req.Id);

        if (existingSeminar is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var seminar = req.ToSeminar();
        await _seminarService.UpdateAsync(seminar);

        var seminarResponse = seminar.ToSeminarResponse();
        await SendOkAsync(seminarResponse, ct);
    }
}