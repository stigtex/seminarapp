using SeminarApplication.Contracts.Responses.CourseResponses;
using SeminarApplication.Contracts.Responses.ParticipantResponses;
using SeminarApplication.Contracts.Responses.SeminarResponses;
using SeminarApplication.Domain;

namespace SeminarApplication.Mapping;

public static class DomainToContractMapper
{
    public static SeminarResponse ToSeminarResponse(this Seminar seminar)
    {
        return new SeminarResponse
        {
            Id = seminar.Id,
            SeminarName = seminar.SeminarName.Value,
            StartDate = seminar.StartDate,
            EndDate = seminar.EndDate
        };
    }
    
    public static GetAllSeminarsResponse ToSeminarResponse(this IEnumerable<Seminar> seminars)
    {
        return new GetAllSeminarsResponse
        {
            Seminars = seminars.Select(x => new SeminarResponse
            {
                Id = x.Id,
                SeminarName = x.SeminarName.Value,
                StartDate = x.StartDate,
                EndDate = x.EndDate
            })
        };
    }

    public static ParticipantResponse ToParticipantResponse(this Participant participant)
    {
        return new ParticipantResponse
        {
            Id = participant.Id,
            FirstName = participant.FirstName.Value,
            LastName = participant.LastName.Value,
            EmailAddress = participant.EmailAddress.Value
        };
    }
    
    public static GetAllParticipantResponse ToParticipantResponse(this IEnumerable<Participant> participant)
    {
        return new GetAllParticipantResponse
        {
            Participants = participant.Select(x => new ParticipantResponse
            {
                Id = x.Id,
                FirstName = x.FirstName.Value,
                LastName = x.LastName.Value,
                EmailAddress = x.EmailAddress.Value
            })
        };
    }
    
    public static CourseResponse ToCourseResponse(this Course course)
    {
        return new CourseResponse
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
    
    public static GetAllCoursesResponse ToCourseResponse(this IEnumerable<Course> courses)
    {
        return new GetAllCoursesResponse
        {
            Courses = courses.Select(x => new CourseResponse
            {
                Id = x.Id,
                CourseName = x.CourseName.Value,
                InstructorFirstName = x.InstructorFirstName.Value,
                InstructorLastName = x.InstructorLastName.Value,
                RoomName = x.RoomName.Value,
                StartDate = x.StartDate,
                EndDate = x.EndDate
            })
        };
    }
    
    public static SeminarCourseResponse ToSeminarCourseResponse(this SeminarCourse seminarCourse)
    {
        return new SeminarCourseResponse
        {
            SeminarId = seminarCourse.SeminarId,
            CourseId = seminarCourse.CourseId
        };
    }
    
    public static GetAllSeminarCoursesResponse ToSeminarCourseResponse(this IEnumerable<Course> courses)
    {
        return new GetAllSeminarCoursesResponse
        {
            Courses = courses.Select(x => new CourseResponse
            {
                Id = x.Id,
                CourseName = x.CourseName.Value,
                InstructorFirstName = x.InstructorFirstName.Value,
                InstructorLastName = x.InstructorLastName.Value,
                RoomName = x.RoomName.Value,
                StartDate = x.StartDate,
                EndDate = x.EndDate
            })
        };
    }
    
    public static CourseParticipantResponse ToCourseParticipantResponse(this CourseParticipant courseParticipant)
    {
        return new CourseParticipantResponse
        {
            CourseId = courseParticipant.CourseId,
            ParticipantId = courseParticipant.ParticipantId
        };
    }

    public static GetAllCourseParticipantsResponse ToCourseParticipantResponse(this IEnumerable<Participant> participants)
    {
        return new GetAllCourseParticipantsResponse
        {
            Participants = participants.Select(x => new ParticipantResponse
            {
                Id = x.Id,
                FirstName = x.FirstName.Value,
                LastName = x.LastName.Value,
                EmailAddress = x.EmailAddress.Value
            })
        };
    }
}