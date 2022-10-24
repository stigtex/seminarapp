using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using SeminarApplication.Contracts.Requests.CourseRequests;
using SeminarApplication.Contracts.Responses.CourseResponses;
using SeminarApplication.Mapping;
using SeminarApplication.Services;

namespace SeminarApplication.Endpoints.CourseEndpoints;

[HttpPost("courses"), AllowAnonymous]
public class CreateCourseEndpoint : Endpoint<CreateCourseRequest, CourseResponse>
{
    private readonly ICourseService _courseService;
    
    public CreateCourseEndpoint(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public override async Task HandleAsync(CreateCourseRequest req, CancellationToken ct)
    {
        var course = req.ToCourse();

        await _courseService.CreateAsync(course);

        var courseResponse = course.ToCourseResponse();
        await SendCreatedAtAsync<GetCourseEndpoint>(
            new { course.Id }, courseResponse, generateAbsoluteUrl: true, cancellation: ct);
    }
}