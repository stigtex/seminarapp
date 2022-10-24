using FluentValidation;
using FluentValidation.Results;
using SeminarApplication.Domain;
using SeminarApplication.Mapping;
using SeminarApplication.Repositories;

namespace SeminarApplication.Services;

public interface IParticipantService
{
    Task<bool> CreateAsync(Participant participant);
    Task<Participant?> GetAsync(int id);
    Task<IEnumerable<Participant>> GetAllAsync();
    Task<bool> UpdateAsync(Participant participant);
    Task<bool> DeleteAsync(int id);
    Task<bool> AddCourseParticipantAsync(CourseParticipant courseParticipant);
    Task<IEnumerable<Participant>> GetAllCourseParticipantsAsync(int courseId);
    Task<bool> RemoveCourseParticipantAsync(int courseId, int participantId);
}

public class ParticipantService : IParticipantService
{
    private readonly IParticipantRepository _participantRepository;

    public ParticipantService(IParticipantRepository participantRepository)
    {
        _participantRepository = participantRepository;
    }

    public async Task<bool> CreateAsync(Participant participant)
    {
        var existingParticipant = await _participantRepository.GetAsync(participant.Id);
        if (existingParticipant is not null)
        {
            var message = $"A participant with id {participant.Id} already exists";
            throw new ValidationException(message, new []
            {
                new ValidationFailure(nameof(Participant), message)
            });
        }

        var participantDto = participant.ToParticipantDto();
        return await _participantRepository.CreateAsync(participantDto);
    }

    public async Task<Participant?> GetAsync(int id)
    {
        var participantDto = await _participantRepository.GetAsync(id);
        return participantDto?.ToParticipant();
    }

    public async Task<IEnumerable<Participant>> GetAllAsync()
    {
        var participantDtos = await _participantRepository.GetAllAsync();
        return participantDtos.Select(x => x.ToParticipant());
    }

    public async Task<bool> UpdateAsync(Participant participant)
    {
        var participantDto = participant.ToParticipantDto();
        return await _participantRepository.UpdateAsync(participantDto);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _participantRepository.DeleteAsync(id);
    }
    
    public async Task<bool> AddCourseParticipantAsync(CourseParticipant courseParticipant)
    {
        var existingCourseParticipant = 
            await _participantRepository.GetCourseParticipantAsync(courseParticipant.CourseId, courseParticipant.ParticipantId);
        if (existingCourseParticipant is not null)
        {
            var message = $"A course participant with course id {courseParticipant.CourseId} and participant id {courseParticipant.ParticipantId} already exists";
            throw new ValidationException(message, new []
            {
                new ValidationFailure(nameof(SeminarCourse), message)
            });
        }

        var courseParticipantDto = courseParticipant.ToCourseParticipantDto();
        return await _participantRepository.AddCourseParticipantAsync(courseParticipantDto);
    }
    
    public async Task<IEnumerable<Participant>> GetAllCourseParticipantsAsync(int courseId)
    {
        var participantDtos = await _participantRepository.GetAllCourseParticipantsAsync(courseId);
        return participantDtos.Select(x => x.ToParticipant());
    }
    
    public async Task<bool> RemoveCourseParticipantAsync(int courseId, int participantId)
    {
        return await _participantRepository.RemoveCourseParticipantAsync(courseId, participantId);
    }
}