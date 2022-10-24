using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using SeminarApplication.Contracts.Responses.ParticipantResponses;
using SeminarApplication.Mapping;
using SeminarApplication.Services;

namespace SeminarApplication.Endpoints.ParticipantEndpoints;

[HttpGet("participants"), AllowAnonymous]
public class GetAllParticipantEndpoint : EndpointWithoutRequest<GetAllParticipantResponse>
{
    private readonly IParticipantService _participantService;
    
    public GetAllParticipantEndpoint(IParticipantService participantService)
    {
        _participantService = participantService;
    }
    
    public override async Task HandleAsync(CancellationToken ct)
    {
        var participants = await _participantService.GetAllAsync();
        var participantsResponse = participants.ToParticipantResponse();
        await SendOkAsync(participantsResponse, ct);
    }
}