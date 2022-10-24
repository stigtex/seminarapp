using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using SeminarApplication.Contracts.Requests.CourseRequests;
using SeminarApplication.Contracts.Responses.CourseResponses;
using SeminarApplication.Mapping;
using SeminarApplication.Services;

namespace SeminarApplication.Endpoints.CourseEndpoints;

[HttpPut("courses/{id:int}"), AllowAnonymous]
public class UpdateCourseEndpoint : Endpoint<UpdateCourseRequest, CourseResponse>
{
    private readonly ICourseService _courseService;
    
    public UpdateCourseEndpoint(ICourseService courseService)
    {
        _courseService = courseService;
    }
    
    public override async Task HandleAsync(UpdateCourseRequest req, CancellationToken ct)
    {
        var existingCourse = await _courseService.GetAsync(req.Id);

        if (existingCourse is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var course = req.ToCourse();
        await _courseService.UpdateAsync(course);

        var courseResponse = course.ToCourseResponse();
        await SendOkAsync(courseResponse, ct);
    }
}