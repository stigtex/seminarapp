using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using SeminarApplication.Contracts.Requests.CourseRequests;
using SeminarApplication.Services;

namespace SeminarApplication.Endpoints.CourseEndpoints;

[HttpPut("courses/delete/{id:int}"), AllowAnonymous]
public class DeleteCourseEndpoint : Endpoint<DeleteCourseRequest>
{
    private readonly ICourseService _courseService;
    
    public DeleteCourseEndpoint(ICourseService courseService)
    {
        _courseService = courseService;
    }
    
    public override async Task HandleAsync(DeleteCourseRequest req, CancellationToken ct)
    {
        var deleted = await _courseService.DeleteAsync(req.Id);
        if (!deleted)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await SendNoContentAsync(ct);
    }
}