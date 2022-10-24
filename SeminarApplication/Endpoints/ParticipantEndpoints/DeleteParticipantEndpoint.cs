using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using SeminarApplication.Contracts.Requests.ParticipantRequests;
using SeminarApplication.Services;

namespace SeminarApplication.Endpoints.ParticipantEndpoints;

[HttpPut("participants/delete/{id:int}"), AllowAnonymous]
public class DeleteParticipantEndpoint : Endpoint<DeleteParticipantRequest>
{
    private readonly IParticipantService _participantService;
    
    public DeleteParticipantEndpoint(IParticipantService participantService)
    {
        _participantService = participantService;
    }

    public override async Task HandleAsync(DeleteParticipantRequest req, CancellationToken ct)
    {
        var deleted = await _participantService.DeleteAsync(req.Id);
        if (!deleted)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await SendNoContentAsync(ct);
    }
}