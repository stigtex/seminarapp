using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using SeminarApplication.Contracts.Requests.CourseRequests;
using SeminarApplication.Services;

namespace SeminarApplication.Endpoints.CourseEndpoints;

[HttpDelete("courses/{courseId:int}/seminar/{seminarId:int}"), AllowAnonymous]
public class RemoveSeminarCourseEndpoint : Endpoint<RemoveSeminarCourseRequest>
{
    private readonly ICourseService _courseService;
    
    public RemoveSeminarCourseEndpoint(ICourseService courseService)
    {
        _courseService = courseService;
    }
    
    public override async Task HandleAsync(RemoveSeminarCourseRequest req, CancellationToken ct)
    {
        var deleted = await _courseService.RemoveSeminarCourseAsync(req.SeminarId, req.CourseId);
        if (!deleted)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await SendNoContentAsync(ct);
    }
}