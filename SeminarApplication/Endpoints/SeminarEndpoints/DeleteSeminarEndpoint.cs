using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using SeminarApplication.Contracts.Requests.SeminarRequests;
using SeminarApplication.Services;

namespace SeminarApplication.Endpoints.SeminarEndpoints;

[HttpPut("seminars/delete/{id:int}"), AllowAnonymous]
public class DeleteSeminarEndpoint : Endpoint<DeleteSeminarRequest>
{
    private readonly ISeminarService _seminarService;
    
    public DeleteSeminarEndpoint(ISeminarService seminarService)
    {
        _seminarService = seminarService;
    }
    
    public override async Task HandleAsync(DeleteSeminarRequest req, CancellationToken ct)
    {
        var deleted = await _seminarService.DeleteAsync(req.Id);
        if (!deleted)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await SendNoContentAsync(ct);
    }
}