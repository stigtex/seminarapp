using Dapper;
using SeminarApplication.Contracts.Data;
using SeminarApplication.Database;

namespace SeminarApplication.Repositories;

public interface ISeminarRepository
{
    Task<bool> CreateAsync(SeminarDto seminar);
    Task<SeminarDto?> GetAsync(int id);
    Task<IEnumerable<SeminarDto>> GetAllAsync();
    Task<bool> UpdateAsync(SeminarDto seminar);
    Task<bool> DeleteAsync(int id);
}

public class SeminarRepository : ISeminarRepository
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public SeminarRepository(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<bool> CreateAsync(SeminarDto seminar)
    {
        using var connection = await _sqlConnectionFactory.CreateConnectionAsync();
        var result = await connection.ExecuteAsync(
            @"INSERT INTO Seminar (SeminarName, StartDate, EndDate)
            VALUES (@SeminarName, @StartDate, @EndDate)", seminar);
        return result > 0;
    }

    public async Task<SeminarDto?> GetAsync(int id)
    {
        using var connection = await _sqlConnectionFactory.CreateConnectionAsync();
        return await connection.QuerySingleOrDefaultAsync<SeminarDto>(
            "SELECT * FROM Seminar WHERE Id = @Id", new { Id = id });
    }

    public async Task<IEnumerable<SeminarDto>> GetAllAsync()
    {
        using var connection = await _sqlConnectionFactory.CreateConnectionAsync();
        return await connection.QueryAsync<SeminarDto>("SELECT * FROM Seminar WHERE DeletedDate IS NULL");
    }

    public async Task<bool> UpdateAsync(SeminarDto seminar)
    {
        using var connection = await _sqlConnectionFactory.CreateConnectionAsync();
        var result = await connection.ExecuteAsync(
            @"UPDATE Seminar
            SET SeminarName = @SeminarName, StartDate = @StartDate, EndDate = @EndDate
            WHERE Id = @Id", seminar);
        return result > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        using var connection = await _sqlConnectionFactory.CreateConnectionAsync();
        var result = await connection.ExecuteAsync(
            @"UPDATE Seminar
            SET DeletedDate = @Date
            WHERE Id = @Id", new {Date = DateTime.Now, Id = id});
        return result > 0;
    }
}