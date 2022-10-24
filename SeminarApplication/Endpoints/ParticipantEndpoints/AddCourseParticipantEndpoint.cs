using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using SeminarApplication.Contracts.Requests.ParticipantRequests;
using SeminarApplication.Contracts.Responses.ParticipantResponses;
using SeminarApplication.Mapping;
using SeminarApplication.Services;

namespace SeminarApplication.Endpoints.ParticipantEndpoints;

[HttpPost("participants/course"), AllowAnonymous]
public class AddCourseParticipantEndpoint  : Endpoint<AddCourseParticipantRequest, CourseParticipantResponse>
{
    private readonly IParticipantService _participantService;
    
    public AddCourseParticipantEndpoint(IParticipantService participantService)
    {
        _participantService = participantService;
    }

    public override async Task HandleAsync(AddCourseParticipantRequest req, CancellationToken ct)
    {
        var courseParticipant = req.ToCourseParticipant();

        await _participantService.AddCourseParticipantAsync(courseParticipant);

        var courseParticipantResponse = courseParticipant.ToCourseParticipantResponse();
        await SendOkAsync(courseParticipantResponse, ct);
    }
}