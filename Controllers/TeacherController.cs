using Microsoft.AspNetCore.Mvc;
using webapi.DTOs;
using webapi.Models;
using webapi.Repositories;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {

        private readonly ITeacherRepository _teacherRepository;

        public TeacherController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Teacher>>> GetAll()
        {
            return Ok(await _teacherRepository.GetAll());

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher?>> GetSingleTeacher(int id)
        {

            return Ok(await _teacherRepository.GetSingleTeacher(id));

        }


        [HttpPost]
        public async Task<ActionResult<Teacher>> AddTeacher(TeacherDto request)
        {
            return Ok(await _teacherRepository.AddTeacher(request));

        }


        [HttpPut("{id}")]
        public async Task<Teacher?> UpdateTeacher(int id, TeacherDto request)
        {

            return await _teacherRepository.UpdateTeacher(id, request);
        }



        [HttpDelete("{id}")]
        public async Task DeleteTeacher(int id)
        {
            await _teacherRepository.DeleteTeacher(id);

        }
    }
}
