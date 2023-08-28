using Microsoft.AspNetCore.Mvc;
using webapi.DTOs;
using webapi.Models;
using webapi.Repositories;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {



        private readonly IAnswerRepository _answerRepository;

        public AnswerController(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;

        }

        [HttpGet]
        public async Task<ActionResult<List<Answer>>> GetAll()
        {
            return Ok(await _answerRepository.GetAll());

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Answer?>> GetSingleAnswer(int id)
        {

            return Ok(await _answerRepository.GetSingleAnswer(id));

        }


        [HttpPost]
        public async Task<ActionResult<Answer>> AddAnswer(AnswerDto request)
        {
            return Ok(await _answerRepository.AddAnswer(request));

        }


        [HttpPut("{id}")]
        public async Task<Answer?> UpdateAnswer(int id, AnswerDto request)
        {

            return await _answerRepository.UpdateAnswer(id, request);
        }



        [HttpDelete("{id}")]
        public async Task DeleteAnswer(int id)
        {
            await _answerRepository.DeleteAnswer(id);

        }




    }
}
