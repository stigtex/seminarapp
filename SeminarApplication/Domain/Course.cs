using SeminarApplication.Domain.Common;

namespace SeminarApplication.Domain;

public class Course
{
    public int Id { get; init; }
    public CourseName CourseName { get; init; } = default!;
    public FirstName InstructorFirstName { get; init; } = default!;
    public LastName InstructorLastName { get; init; } = default!;
    public RoomName RoomName { get; init; } = default!;
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
}