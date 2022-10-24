using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using SeminarApplication.Contracts.Responses.SeminarResponses;
using SeminarApplication.Mapping;
using SeminarApplication.Services;

namespace SeminarApplication.Endpoints.SeminarEndpoints;

[HttpGet("seminars"), AllowAnonymous]
public class GetAllSeminarsEndpoint : EndpointWithoutRequest<GetAllSeminarsResponse>
{
    private readonly ISeminarService _seminarService;
    
    public GetAllSeminarsEndpoint(ISeminarService seminarService)
    {
        _seminarService = seminarService;
    }
    
    public override async Task HandleAsync(CancellationToken ct)
    {
        var seminars = await _seminarService.GetAllAsync();
        var seminarsResponse = seminars.ToSeminarResponse();
        await SendOkAsync(seminarsResponse, ct);
    }
}