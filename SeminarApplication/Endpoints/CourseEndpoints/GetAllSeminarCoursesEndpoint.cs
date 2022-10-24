using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using SeminarApplication.Contracts.Requests.CourseRequests;
using SeminarApplication.Contracts.Responses.CourseResponses;
using SeminarApplication.Mapping;
using SeminarApplication.Services;

namespace SeminarApplication.Endpoints.CourseEndpoints;

[HttpGet("courses/seminar/{seminarId:int}"), AllowAnonymous]
public class GetAllSeminarCoursesEndpoint : Endpoint<GetSeminarCoursesRequest, GetAllSeminarCoursesResponse>
{
    private readonly ICourseService _courseService;
    
    public GetAllSeminarCoursesEndpoint(ICourseService courseService)
    {
        _courseService = courseService;
    }
    
    public override async Task HandleAsync(GetSeminarCoursesRequest req, CancellationToken ct)
    {
        var courses = await _courseService.GetAllSeminarCoursesAsync(req.SeminarId);
        var seminarCourseResponse = courses.ToSeminarCourseResponse();
        await SendOkAsync(seminarCourseResponse, ct);
    }
}