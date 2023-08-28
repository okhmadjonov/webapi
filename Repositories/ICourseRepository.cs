using Microsoft.AspNetCore.Mvc;
using webapi.DTOs;
using webapi.Models;

namespace webapi.Repositories
{
    public interface ICourseRepository
    {
        Task<ActionResult<List<Course>>> GetAllCourses();
        Task<Course?> GetSingleCourse(int id);
        Task<Course> AddCourse(CourseDto request);
        Task<Course?> UpdateCourse(int id, CourseDto request);
        Task DeleteCourse(int id);

    }
}
