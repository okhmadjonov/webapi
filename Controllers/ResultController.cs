using Microsoft.AspNetCore.Mvc;
using webapi.DTOs;
using webapi.Models;
using webapi.Repositories;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private readonly IResultRepository _resultRepository;

        public ResultController(IResultRepository resultRepository)
        {
            _resultRepository = resultRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetAll()
        {
            return Ok(await _resultRepository.GetAll());

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Result?>> GetSingleResult(int id)
        {

            return Ok(await _resultRepository.GetSingleResult(id));

        }


        [HttpPost]
        public async Task<ActionResult<Result>> AddResult(ResultDto request)
        {
            return Ok(await _resultRepository.AddResult(request));

        }


        [HttpPut("{id}")]
        public async Task<Result?> UpdateResult(int id, ResultDto request)
        {

            return await _resultRepository.UpdateResult(id, request);
        }



        [HttpDelete("{id}")]
        public async Task DeleteResult(int id)
        {
            await _resultRepository.DeleteResult(id);

        }


    }
}
