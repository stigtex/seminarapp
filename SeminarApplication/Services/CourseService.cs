using FluentValidation;
using FluentValidation.Results;
using SeminarApplication.Domain;
using SeminarApplication.Mapping;
using SeminarApplication.Repositories;

namespace SeminarApplication.Services;

public interface ICourseService
{
    Task<bool> CreateAsync(Course course);
    Task<Course?> GetAsync(int id);
    Task<IEnumerable<Course>> GetAllAsync();
    Task<bool> UpdateAsync(Course course);
    Task<bool> DeleteAsync(int id);
    Task<bool> AddSeminarCourseAsync(SeminarCourse seminarCourse);
    Task<IEnumerable<Course>> GetAllSeminarCoursesAsync(int seminarId);
    Task<bool> RemoveSeminarCourseAsync(int seminarId, int courseId);
}

public class CourseService : ICourseService
{
    private readonly ICourseRepository _courseRepository;

    public CourseService(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<bool> CreateAsync(Course course)
    {
        var existingCourse = await _courseRepository.GetAsync(course.Id);
        if (existingCourse is not null)
        {
            var message = $"A course with id {course.Id} already exists";
            throw new ValidationException(message, new []
            {
                new ValidationFailure(nameof(Course), message)
            });
        }

        var courseDto = course.ToCourseDto();
        return await _courseRepository.CreateAsync(courseDto);
    }

    public async Task<Course?> GetAsync(int id)
    {
        var courseDto = await _courseRepository.GetAsync(id);
        return courseDto?.ToCourse();
    }

    public async Task<IEnumerable<Course>> GetAllAsync()
    {
        var courseDtos = await _courseRepository.GetAllAsync();
        return courseDtos.Select(x => x.ToCourse());
    }

    public async Task<bool> UpdateAsync(Course course)
    {
        var courseDto = course.ToCourseDto();
        return await _courseRepository.UpdateAsync(courseDto);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _courseRepository.DeleteAsync(id);
    }
    
    public async Task<bool> AddSeminarCourseAsync(SeminarCourse seminarCourse)
    {
        var existingSeminarCourse = 
            await _courseRepository.GetSeminarCourseAsync(seminarCourse.SeminarId, seminarCourse.CourseId);
        if (existingSeminarCourse is not null)
        {
            var message = $"A seminar course with seminar id {seminarCourse.SeminarId} and course id {seminarCourse.CourseId} already exists";
            throw new ValidationException(message, new []
            {
                new ValidationFailure(nameof(SeminarCourse), message)
            });
        }

        var seminarCourseDto = seminarCourse.ToSeminarCourseDto();
        return await _courseRepository.AddSeminarCourseAsync(seminarCourseDto);
    }
    
    public async Task<IEnumerable<Course>> GetAllSeminarCoursesAsync(int seminarId)
    {
        var courseDtos = await _courseRepository.GetAllSeminarCoursesAsync(seminarId);
        return courseDtos.Select(x => x.ToCourse());
    }
    
    public async Task<bool> RemoveSeminarCourseAsync(int seminarId, int courseId)
    {
        return await _courseRepository.RemoveSeminarCourseAsync(seminarId, courseId);
    }
}