using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using SeminarApplication.Contracts.Requests.ParticipantRequests;
using SeminarApplication.Services;

namespace SeminarApplication.Endpoints.ParticipantEndpoints;

[HttpDelete("participants/{participantId:int}/course/{courseId:int}"), AllowAnonymous]
public class RemoveCourseParticipantEndpoint : Endpoint<RemoveCourseParticipantRequest>
{
    private readonly IParticipantService _participantService;
    
    public RemoveCourseParticipantEndpoint(IParticipantService participantService)
    {
        _participantService = participantService;
    }
    
    public override async Task HandleAsync(RemoveCourseParticipantRequest req, CancellationToken ct)
    {
        var deleted = await _participantService.RemoveCourseParticipantAsync(req.CourseId, req.ParticipantId);
        if (!deleted)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await SendNoContentAsync(ct);
    }
}