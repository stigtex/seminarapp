using FluentValidation;
using SeminarApplication.Contracts.Requests.ParticipantRequests;

namespace SeminarApplication.Validation.ParticipantValidation;

public class AddCourseParticipantValidator : AbstractValidator<AddCourseParticipantRequest>
{
    public AddCourseParticipantValidator()
    {
        RuleFor(x => x.CourseId).NotEmpty();
        RuleFor(x => x.ParticipantId).NotEmpty();
    }
}