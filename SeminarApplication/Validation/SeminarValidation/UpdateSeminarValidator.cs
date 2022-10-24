using FluentValidation;
using SeminarApplication.Contracts.Requests.SeminarRequests;

namespace SeminarApplication.Validation.SeminarValidation;

public class UpdateSeminarValidator : AbstractValidator<UpdateSeminar>
{
    public UpdateSeminarValidator()
    {
        RuleFor(x => x.SeminarName).NotEmpty();
        RuleFor(x => x.StartDate).NotEmpty();
        RuleFor(x => x.EndDate).NotEmpty();
    }
}