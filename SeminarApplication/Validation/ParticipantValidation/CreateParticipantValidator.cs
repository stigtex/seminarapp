using FluentValidation;
using SeminarApplication.Contracts.Requests.ParticipantRequests;

namespace SeminarApplication.Validation.ParticipantValidation;

public class CreateParticipantValidator : AbstractValidator<CreateParticipantRequest>
{
    public CreateParticipantValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.EmailAddress).NotEmpty();
    }
}