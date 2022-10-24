using FluentValidation;
using SeminarApplication.Contracts.Requests.CourseRequests;

namespace SeminarApplication.Validation.CourseValidation;

public class AddSeminarCourseValidator  : AbstractValidator<AddSeminarCourseRequest>
{
    public AddSeminarCourseValidator()
    {
        RuleFor(x => x.SeminarId).NotEmpty();
        RuleFor(x => x.CourseId).NotEmpty();
    }
}