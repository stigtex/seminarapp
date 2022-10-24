using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using SeminarApplication.Contracts.Requests.SeminarRequests;
using SeminarApplication.Contracts.Responses.SeminarResponses;
using SeminarApplication.Mapping;
using SeminarApplication.Services;

namespace SeminarApplication.Endpoints.SeminarEndpoints;

[HttpPost("seminars"), AllowAnonymous]
public class CreateSeminarEndpoint : Endpoint<CreateSeminarRequest, SeminarResponse>
{
    private readonly ISeminarService _seminarService;
    
    public CreateSeminarEndpoint(ISeminarService seminarService)
    {
        _seminarService = seminarService;
    }

    public override async Task HandleAsync(CreateSeminarRequest req, CancellationToken ct)
    {
        var seminar = req.ToSeminar();

        await _seminarService.CreateAsync(seminar);

        var seminarResponse = seminar.ToSeminarResponse();
        await SendCreatedAtAsync<GetSeminarEndpoint>(
            new { seminar.Id }, seminarResponse, generateAbsoluteUrl: true, cancellation: ct);
    }
}