using Microsoft.AspNetCore.Mvc;
using webapi.DTOs;
using webapi.Models;
using webapi.Repositories;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Course>>> GetAllCourses()
        {
            return Ok(await _courseRepository.GetAllCourses());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Course?>> GetSingleCourse(int id)
        {

            return Ok(await _courseRepository.GetSingleCourse(id));
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<Course>> AddCourse(CourseDto request)
        {
            return Ok(await _courseRepository.AddCourse(request));

        }

        [HttpPut("{id}")]
        public async Task<Course?> UpdateCourse(int id, CourseDto request)
        {

            return await _courseRepository.UpdateCourse(id, request);
        }

        [HttpDelete("{id}")]
        public async Task DeleteCourse(int id)
        {
            await _courseRepository.DeleteCourse(id);
        }

    }
}
