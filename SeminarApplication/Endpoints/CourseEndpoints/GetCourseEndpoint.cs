using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using SeminarApplication.Contracts.Requests.CourseRequests;
using SeminarApplication.Contracts.Responses.CourseResponses;
using SeminarApplication.Mapping;
using SeminarApplication.Services;

namespace SeminarApplication.Endpoints.CourseEndpoints;

[HttpGet("courses/{id:int}"), AllowAnonymous]
public class GetCourseEndpoint : Endpoint<GetCourseRequest, CourseResponse>
{
    private readonly ICourseService _courseService;
    
    public GetCourseEndpoint(ICourseService courseService)
    {
        _courseService = courseService;
    }
    
    public override async Task HandleAsync(GetCourseRequest req, CancellationToken ct)
    {
        var course = await _courseService.GetAsync(req.Id);

        if (course is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var courseResponse = course.ToCourseResponse();
        await SendOkAsync(courseResponse, ct);
    }
}