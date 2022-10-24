using SeminarApplication.Contracts.Data;
using SeminarApplication.Domain;

namespace SeminarApplication.Mapping;

public static class DomainToDtoMapper
{
    public static SeminarDto ToSeminarDto(this Seminar seminar)
    {
        return new SeminarDto
        {
            Id = seminar.Id,
            SeminarName = seminar.SeminarName.Value,
            StartDate = seminar.StartDate,
            EndDate = seminar.EndDate
        };
    }

    public static ParticipantDto ToParticipantDto(this Participant participant)
    {
        return new ParticipantDto
        {
            Id = participant.Id,
            FirstName = participant.FirstName.Value,
            LastName = participant.LastName.Value,
            EmailAddress = participant.EmailAddress.Value
        };
    }
    
    public static CourseDto ToCourseDto(this Course course)
    {
        return new CourseDto
        {
            Id = course.Id,
            CourseName = course.CourseName.Value,
            InstructorFirstName = course.InstructorFirstName.Value,
            InstructorLastName = course.InstructorLastName.Value,
            RoomName = course.RoomName.Value,
            StartDate = course.StartDate,
            EndDate = course.EndDate
        };
    }
    
    public static SeminarCourseDto ToSeminarCourseDto(this SeminarCourse seminarCourse)
    {
        return new SeminarCourseDto
        {
            SeminarId = seminarCourse.SeminarId,
            CourseId = seminarCourse.CourseId
        };
    }
    
    public static CourseParticipantDto ToCourseParticipantDto(this CourseParticipant courseParticipant)
    {
        return new CourseParticipantDto
        {
            CourseId = courseParticipant.CourseId,
            ParticipantId = courseParticipant.ParticipantId
        };
    }
}