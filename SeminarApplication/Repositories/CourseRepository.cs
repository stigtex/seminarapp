using Dapper;
using SeminarApplication.Contracts.Data;
using SeminarApplication.Database;

namespace SeminarApplication.Repositories;

public interface ICourseRepository
{
    Task<bool> CreateAsync(CourseDto course);
    Task<CourseDto?> GetAsync(int id);
    Task<IEnumerable<CourseDto>> GetAllAsync();
    Task<bool> UpdateAsync(CourseDto course);
    Task<bool> DeleteAsync(int id);
    Task<bool> AddSeminarCourseAsync(SeminarCourseDto seminarCourse);
    Task<SeminarCourseDto?> GetSeminarCourseAsync(int seminarId, int courseId);
    Task<IEnumerable<CourseDto>> GetAllSeminarCoursesAsync(int seminarId);
    Task<bool> RemoveSeminarCourseAsync(int seminarId, int courseId);
}

public class CourseRepository : ICourseRepository
{
    private readonly ISqlConnectionFactory _connectionFactory;

    public CourseRepository(ISqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<bool> CreateAsync(CourseDto course)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        var result = await connection.ExecuteAsync(
            @"INSERT INTO Course (CourseName, InstructorFirstName, InstructorLastName, RoomName, StartDate, EndDate) 
            VALUES (@CourseName, @InstructorFirstName, @InstructorLastName, @RoomName, @StartDate, @EndDate)", course);
        return result > 0;
    }

    public async Task<CourseDto?> GetAsync(int id)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        return await connection.QuerySingleOrDefaultAsync<CourseDto>(
            "SELECT * FROM Course WHERE Id = @Id", new { Id = id });
    }

    public async Task<IEnumerable<CourseDto>> GetAllAsync()
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        return await connection.QueryAsync<CourseDto>("SELECT * FROM Course WHERE DeletedDate IS NULL");
    }

    public async Task<bool> UpdateAsync(CourseDto course)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        var result = await connection.ExecuteAsync(@"UPDATE Course
            SET CourseName = @CourseName, InstructorFirstName = @InstructorFirstName, 
                InstructorLastName = @InstructorLastName, RoomName = @RoomName, StartDate = @StartDate, EndDate = @EndDate
            WHERE Id = @Id", course);
        return result > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        var result = await connection.ExecuteAsync(@"UPDATE Course
            SET InstructorFirstName = 'Anon', InstructorLastName = 'Anon', DeletedDate = @Date
            WHERE Id = @Id", new {Date = DateTime.Now, Id = id});
        return result > 0;
    }
    
    public async Task<bool> AddSeminarCourseAsync(SeminarCourseDto seminarCourse)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        var result = await connection.ExecuteAsync(
            @"INSERT INTO SeminarCourse (SeminarId, CourseId) 
            VALUES (@SeminarId, @CourseId)", seminarCourse);
        return result > 0;
    }
    
    public async Task<SeminarCourseDto?> GetSeminarCourseAsync(int seminarId, int courseId)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        return await connection.QuerySingleOrDefaultAsync<SeminarCourseDto>(
            "SELECT * FROM SeminarCourse WHERE SeminarId = @SeminarId AND CourseId = @CourseId", 
            new {SeminarId = seminarId, CourseId = courseId});
    }
    
    public async Task<IEnumerable<CourseDto>> GetAllSeminarCoursesAsync(int seminarId)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        return await connection.QueryAsync<CourseDto>(@"SELECT * FROM Course CO
            JOIN SeminarCourse SC on CO.Id = SC.CourseId 
            WHERE SC.SeminarId = @SeminarId AND CO.DeletedDate IS NULL",
            new {SeminarId = seminarId});
    }
    
    public async Task<bool> RemoveSeminarCourseAsync(int seminarId, int courseId)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        var result = await connection.ExecuteAsync(
            @"DELETE FROM SeminarCourse WHERE SeminarId = @SeminarId AND CourseId = @CourseId",
            new {SeminarId = seminarId, CourseId = courseId});
        return result > 0;
    }
}