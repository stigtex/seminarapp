using SeminarApplication.Domain.Common;

namespace SeminarApplication.Domain;

public class Participant
{
    public int Id { get; init; }
    public FirstName FirstName { get; init; } = default!;
    public LastName LastName { get; init; } = default!;
    public EmailAddress EmailAddress { get; init; } = default!;
}