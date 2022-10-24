using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using SeminarApplication.Contracts.Requests.ParticipantRequests;
using SeminarApplication.Contracts.Responses.ParticipantResponses;
using SeminarApplication.Mapping;
using SeminarApplication.Services;

namespace SeminarApplication.Endpoints.ParticipantEndpoints;

[HttpGet("participants/{id:int}"), AllowAnonymous]
public class GetParticipantEndpoint : Endpoint<GetParticipantRequest, ParticipantResponse>
{   
    private readonly IParticipantService _participantService;
    
    public GetParticipantEndpoint(IParticipantService participantService)
    {
        _participantService = participantService;
    }
    
    public override async Task HandleAsync(GetParticipantRequest req, CancellationToken ct)
    {
        var participant = await _participantService.GetAsync(req.Id);

        if (participant is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var participantResponse = participant.ToParticipantResponse();
        await SendOkAsync(participantResponse, ct);
    }
}