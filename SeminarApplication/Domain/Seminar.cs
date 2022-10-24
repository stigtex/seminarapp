using SeminarApplication.Domain.Common;

namespace SeminarApplication.Domain;

public class Seminar
{
    public int Id { get; init; }
    public SeminarName SeminarName { get; init; } = default!;
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
}