using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using SeminarApplication.Contracts.Responses.CourseResponses;
using SeminarApplication.Mapping;
using SeminarApplication.Services;

namespace SeminarApplication.Endpoints.CourseEndpoints;

[HttpGet("courses"), AllowAnonymous]
public class GetAllCoursesEndpoint : EndpointWithoutRequest<GetAllCoursesResponse>
{
    private readonly ICourseService _courseService;
    
    public GetAllCoursesEndpoint(ICourseService courseService)
    {
        _courseService = courseService;
    }
    
    public override async Task HandleAsync(CancellationToken ct)
    {
        var courses = await _courseService.GetAllAsync();
        var coursesResponse = courses.ToCourseResponse();
        await SendOkAsync(coursesResponse, ct);
    }
}