using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using SeminarApplication.Contracts.Requests.CourseRequests;
using SeminarApplication.Contracts.Responses.CourseResponses;
using SeminarApplication.Mapping;
using SeminarApplication.Services;

namespace SeminarApplication.Endpoints.CourseEndpoints;

[HttpPost("courses/seminar"), AllowAnonymous]
public class AddSeminarCourseEndpoint : Endpoint<AddSeminarCourseRequest, SeminarCourseResponse>
{
    private readonly ICourseService _courseService;
    
    public AddSeminarCourseEndpoint(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public override async Task HandleAsync(AddSeminarCourseRequest req, CancellationToken ct)
    {
        var seminarCourse = req.ToSeminarCourse();

        await _courseService.AddSeminarCourseAsync(seminarCourse);

        var seminarCourseResponse = seminarCourse.ToSeminarCourseResponse();
        await SendOkAsync(seminarCourseResponse, ct);
    }
}