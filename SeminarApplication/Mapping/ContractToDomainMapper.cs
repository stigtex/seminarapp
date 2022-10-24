using SeminarApplication.Contracts.Requests.CourseRequests;
using SeminarApplication.Contracts.Requests.ParticipantRequests;
using SeminarApplication.Contracts.Requests.SeminarRequests;
using SeminarApplication.Domain;
using SeminarApplication.Domain.Common;

namespace SeminarApplication.Mapping;

public static class ContractToDomainMapper
{
    public static Seminar ToSeminar(this CreateSeminar request)
    {
        return new Seminar
        {
            SeminarName = SeminarName.From(request.SeminarName),
            StartDate = request.StartDate,
            EndDate = request.EndDate
        };
    }
    
    public static Seminar ToSeminar(this UpdateSeminar request)
    {
        return new Seminar
        {
            Id = request.Id,
            SeminarName = SeminarName.From(request.SeminarName),
            StartDate = request.StartDate,
            EndDate = request.EndDate
        };
    }

    public static Participant ToParticipant(this CreateParticipant request)
    {
        return new Participant
        {
            FirstName = FirstName.From(request.FirstName),
            LastName = LastName.From(request.LastName),
            EmailAddress = EmailAddress.From(request.EmailAddress)
        };
    }
    
    public static Participant ToParticipant(this UpdateParticipant request)
    {
        return new Participant
        {
            Id = request.Id,
            FirstName = FirstName.From(request.FirstName),
            LastName = LastName.From(request.LastName),
            EmailAddress = EmailAddress.From(request.EmailAddress)
        };
    }
    
    public static Course ToCourse(this CreateCourseRequest request)
    {
        return new Course
        {
            CourseName = CourseName.From(request.CourseName),
            InstructorFirstName = FirstName.From(request.InstructorFirstName),
            InstructorLastName = LastName.From(request.InstructorLastName),
            RoomName = RoomName.From(request.RoomName),
            StartDate = request.StartDate,
            EndDate = request.EndDate
        };
    }
    
    public static Course ToCourse(this UpdateCourseRequest request)
    {
        return new Course
        {
            Id = request.Id,
            CourseName = CourseName.From(request.CourseName),
            InstructorFirstName = FirstName.From(request.InstructorFirstName),
            InstructorLastName = LastName.From(request.InstructorLastName),
            RoomName = RoomName.From(request.RoomName),
            StartDate = request.StartDate,
            EndDate = request.EndDate
        };
    }
    
    public static SeminarCourse ToSeminarCourse(this AddSeminarCourseRequest request)
    {
        return new SeminarCourse
        {
            SeminarId = request.SeminarId,
            CourseId = request.CourseId
        };
    }
    
    public static CourseParticipant ToCourseParticipant(this AddCourseParticipantRequest request)
    {
        return new CourseParticipant
        {
            CourseId = request.CourseId,
            ParticipantId = request.ParticipantId
        };
    }
}