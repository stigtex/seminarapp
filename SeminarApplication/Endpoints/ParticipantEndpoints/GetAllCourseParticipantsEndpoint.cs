using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using SeminarApplication.Contracts.Requests.ParticipantRequests;
using SeminarApplication.Contracts.Responses.ParticipantResponses;
using SeminarApplication.Mapping;
using SeminarApplication.Services;

namespace SeminarApplication.Endpoints.ParticipantEndpoints;

[HttpGet("participants/course/{courseId:int}"), AllowAnonymous]
public class GetAllCourseParticipantsEndpoint : Endpoint<GetCourseParticipantsRequest, GetAllCourseParticipantsResponse>
{
    private readonly IParticipantService _participantService;
    
    public GetAllCourseParticipantsEndpoint(IParticipantService participantService)
    {
        _participantService = participantService;
    }
    
    public override async Task HandleAsync(GetCourseParticipantsRequest req, CancellationToken ct)
    {
        var participants = await _participantService.GetAllCourseParticipantsAsync(req.CourseId);
        var courseParticipantResponse = participants.ToCourseParticipantResponse();
        await SendOkAsync(courseParticipantResponse, ct);
    }
}