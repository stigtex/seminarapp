using FluentValidation;
using SeminarApplication.Contracts.Requests.SeminarRequests;

namespace SeminarApplication.Validation.SeminarValidation;

public class CreateSeminarValidator : AbstractValidator<CreateSeminar>
{
    public CreateSeminarValidator()
    {
        RuleFor(x => x.SeminarName).NotEmpty();
        RuleFor(x => x.StartDate).NotEmpty();
        RuleFor(x => x.EndDate).NotEmpty();
    }
}