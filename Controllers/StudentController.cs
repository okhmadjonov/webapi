using Microsoft.AspNetCore.Mvc;
using webapi.DTOs;
using webapi.Models;
using webapi.Repositories;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {


        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;

        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetAll()
        {
            return Ok(await _studentRepository.GetAll());

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Student?>> GetSingleStudent(int id)
        {

            return Ok(await _studentRepository.GetSingleStudent(id));

        }


        [HttpPost]
        public async Task<ActionResult<Student>> AddStudent(StudentDto request)
        {
            return Ok(await _studentRepository.AddStudent(request));

        }


        [HttpPut("{id}")]
        public async Task<Student?> UpdateStudent(int id, StudentDto request)
        {

            return await _studentRepository.UpdateStudent(id, request);
        }



        [HttpDelete("{id}")]
        public async Task DeleteStudent(int id)
        {
            await _studentRepository.DeleteStudent(id);

        }


    }


}
