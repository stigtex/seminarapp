using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using SeminarApplication.Contracts.Requests.ParticipantRequests;
using SeminarApplication.Contracts.Responses.ParticipantResponses;
using SeminarApplication.Mapping;
using SeminarApplication.Services;

namespace SeminarApplication.Endpoints.ParticipantEndpoints;

[HttpPut("participants/{id:int}"), AllowAnonymous]
public class UpdateParticipantEndpoint : Endpoint<UpdateParticipantRequest, ParticipantResponse>
{
    private readonly IParticipantService _participantService;
    
    public UpdateParticipantEndpoint(IParticipantService participantService)
    {
        _participantService = participantService;
    }
    
    public override async Task HandleAsync(UpdateParticipantRequest req, CancellationToken ct)
    {
        var existingParticipant = await _participantService.GetAsync(req.Id);

        if (existingParticipant is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var participant = req.ToParticipant();
        await _participantService.UpdateAsync(participant);

        var participantResponse = participant.ToParticipantResponse();
        await SendOkAsync(participantResponse, ct);
    }
}