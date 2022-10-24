using FluentValidation;
using FluentValidation.Results;
using SeminarApplication.Domain;
using SeminarApplication.Mapping;
using SeminarApplication.Repositories;

namespace SeminarApplication.Services;

public interface ISeminarService
{
    Task<bool> CreateAsync(Seminar seminar);
    Task<Seminar?> GetAsync(int id);
    Task<IEnumerable<Seminar>> GetAllAsync();
    Task<bool> UpdateAsync(Seminar seminar);
    Task<bool> DeleteAsync(int id);
}

public class SeminarService : ISeminarService
{
    private readonly ISeminarRepository _seminarRepository;

    public SeminarService(ISeminarRepository seminarRepository)
    {
        _seminarRepository = seminarRepository;
    }

    public async Task<bool> CreateAsync(Seminar seminar)
    {
        var existingSeminar = await _seminarRepository.GetAsync(seminar.Id);
        if (existingSeminar is not null)
        {
            var message = $"A seminar with id {seminar.Id} already exists";
            throw new ValidationException(message, new []
            {
                new ValidationFailure(nameof(Seminar), message)
            });
        }

        var seminarDto = seminar.ToSeminarDto();
        return await _seminarRepository.CreateAsync(seminarDto);
    }

    public async Task<Seminar?> GetAsync(int id)
    {
        var seminarDto = await _seminarRepository.GetAsync(id);
        return seminarDto?.ToSeminar();
    }

    public async Task<IEnumerable<Seminar>> GetAllAsync()
    {
        var seminarDtos = await _seminarRepository.GetAllAsync();
        return seminarDtos.Select(x => x.ToSeminar());
    }

    public async Task<bool> UpdateAsync(Seminar seminar)
    {
        var seminarDto = seminar.ToSeminarDto();
        return await _seminarRepository.UpdateAsync(seminarDto);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _seminarRepository.DeleteAsync(id);
    }
}