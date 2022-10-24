using FluentValidation;
using SeminarApplication.Contracts.Requests.CourseRequests;

namespace SeminarApplication.Validation.CourseValidation;

public class UpdateCourseValidator : AbstractValidator<UpdateCourseRequest>
{
    public UpdateCourseValidator()
    {
        RuleFor(x => x.CourseName).NotEmpty();
        RuleFor(x => x.InstructorFirstName).NotEmpty();
        RuleFor(x => x.InstructorLastName).NotEmpty();
        RuleFor(x => x.RoomName).NotEmpty();
        RuleFor(x => x.StartDate).NotEmpty();
        RuleFor(x => x.EndDate).NotEmpty();
    }
}