using Dapper;
using SeminarApplication.Contracts.Data;
using SeminarApplication.Database;

namespace SeminarApplication.Repositories;

public interface IParticipantRepository
{
    Task<bool> CreateAsync(ParticipantDto participant);
    Task<ParticipantDto?> GetAsync(int id);
    Task<IEnumerable<ParticipantDto>> GetAllAsync();
    Task<bool> UpdateAsync(ParticipantDto participant);
    Task<bool> DeleteAsync(int id);
    Task<bool> AddCourseParticipantAsync(CourseParticipantDto courseParticipant);
    Task<CourseParticipantDto?> GetCourseParticipantAsync(int courseId, int participantId);
    Task<IEnumerable<ParticipantDto>> GetAllCourseParticipantsAsync(int courseId);
    Task<bool> RemoveCourseParticipantAsync(int courseId, int participantId);
}

public class ParticipantRepository : IParticipantRepository
{
    private readonly ISqlConnectionFactory _connectionFactory;

    public ParticipantRepository(ISqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<bool> CreateAsync(ParticipantDto participant)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        var result = await connection.ExecuteAsync(
            @"INSERT INTO Participant (FirstName, LastName, EmailAddress) 
            VALUES (@FirstName, @LastName, @EmailAddress)", participant);
        return result > 0;
    }

    public async Task<ParticipantDto?> GetAsync(int id)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        return await connection.QuerySingleOrDefaultAsync<ParticipantDto>(
            "SELECT * FROM Participant WHERE Id = @Id", new { Id = id });
    }

    public async Task<IEnumerable<ParticipantDto>> GetAllAsync()
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        return await connection.QueryAsync<ParticipantDto>("SELECT * FROM Participant WHERE DeletedDate IS NULL");
    }

    public async Task<bool> UpdateAsync(ParticipantDto participant)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        var result = await connection.ExecuteAsync(
            @"UPDATE Participant
            SET FirstName = @FirstName, LastName = @LastName, EmailAddress = @EmailAddress
            WHERE Id = @Id", participant);
        return result > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        var result = await connection.ExecuteAsync(
            @"UPDATE Participant 
            SET FirstName = 'Anon', LastName = 'Anon', EmailAddress = 'anon@anon.com', DeletedDate = @Date
            WHERE Id = @Id", new {Date = DateTime.Now, Id = id});
        return result > 0;
    }
    
    public async Task<bool> AddCourseParticipantAsync(CourseParticipantDto courseParticipant)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        var result = await connection.ExecuteAsync(
            @"INSERT INTO CourseParticipant (CourseId, ParticipantId) 
            VALUES (@CourseId, @ParticipantId)", courseParticipant);
        return result > 0;
    }
    
    public async Task<CourseParticipantDto?> GetCourseParticipantAsync(int courseId, int participantId)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        return await connection.QuerySingleOrDefaultAsync<CourseParticipantDto>(
            "SELECT * FROM CourseParticipant WHERE CourseId = @courseId AND ParticipantId = @participantId", 
            new {CourseId = courseId, ParticipantId = participantId});
    }
    
    public async Task<IEnumerable<ParticipantDto>> GetAllCourseParticipantsAsync(int courseId)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        return await connection.QueryAsync<ParticipantDto>(@"SELECT * FROM Participant PA
            JOIN CourseParticipant CP on PA.Id = CP.ParticipantId
            WHERE CP.CourseId = @CourseId AND PA.DeletedDate IS NULL",
            new {CourseId = courseId});
    }
    
    public async Task<bool> RemoveCourseParticipantAsync(int courseId, int participantId)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        var result = await connection.ExecuteAsync(
            @"DELETE FROM CourseParticipant WHERE CourseId = @CourseId AND ParticipantId = @ParticipantId",
            new {CourseId = courseId, ParticipantId = participantId});
        return result > 0;
    }
}