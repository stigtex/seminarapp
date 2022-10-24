using SeminarApplication.Contracts.Data;
using SeminarApplication.Domain;
using SeminarApplication.Domain.Common;

namespace SeminarApplication.Mapping;

public static class DtoToDomainMapper
{
    public static Seminar ToSeminar(this SeminarDto seminarDto)
    {
        return new Seminar
        {
            Id = seminarDto.Id,
            SeminarName = SeminarName.From(seminarDto.SeminarName),
            StartDate = seminarDto.StartDate,
            EndDate = seminarDto.EndDate
        };
    }

    public static Participant ToParticipant(this ParticipantDto participant)
    {
        return new Participant
        {
            Id = participant.Id,
            FirstName = FirstName.From(participant.FirstName),
            LastName = LastName.From(participant.LastName),
            EmailAddress = EmailAddress.From(participant.EmailAddress)
        };
    }
    
    public static Course ToCourse(this CourseDto courseDto)
    {
        return new Course
        {
            Id = courseDto.Id,
            CourseName = CourseName.From(courseDto.CourseName),
            InstructorFirstName = FirstName.From(courseDto.InstructorFirstName),
            InstructorLastName = LastName.From(courseDto.InstructorLastName),
            RoomName = RoomName.From(courseDto.RoomName),
            StartDate = courseDto.StartDate,
            EndDate = courseDto.EndDate
        };
    }
}