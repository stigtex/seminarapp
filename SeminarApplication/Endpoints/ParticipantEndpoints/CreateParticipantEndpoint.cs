using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using SeminarApplication.Contracts.Requests.ParticipantRequests;
using SeminarApplication.Contracts.Responses.ParticipantResponses;
using SeminarApplication.Mapping;
using SeminarApplication.Services;

namespace SeminarApplication.Endpoints.ParticipantEndpoints;

[HttpPost("participants"), AllowAnonymous]
public class CreateParticipantEndpoint : Endpoint<CreateParticipant, ParticipantResponse>
{
    private readonly IParticipantService _participantService;
    
    public CreateParticipantEndpoint(IParticipantService participantService)
    {
        _participantService = participantService;
    }

    public override async Task HandleAsync(CreateParticipant req, CancellationToken ct)
    {
        var participant = req.ToParticipant();

        await _participantService.CreateAsync(participant);

        var participantResponse = participant.ToParticipantResponse();
        await SendCreatedAtAsync<GetParticipantEndpoint>(
            new { participant.Id }, participantResponse, generateAbsoluteUrl: true, cancellation: ct);
    }
}