using Microsoft.AspNetCore.Mvc;
using webapi.DTOs;
using webapi.Models;
using webapi.Repositories;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {

        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackController(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }


        [HttpGet]
        public async Task<ActionResult<List<Feedback>>> GetAll()
        {
            return Ok(await _feedbackRepository.GetAll());

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Feedback?>> GetSingleFeedback(int id)
        {

            return Ok(await _feedbackRepository.GetSingleFeedback(id));

        }


        [HttpPost]
        public async Task<ActionResult<Feedback>> AddFeedback(FeedbackDto request)
        {
            return Ok(await _feedbackRepository.AddFeedback(request));

        }


        [HttpPut("{id}")]
        public async Task<Feedback?> UpdateFeedback(int id, FeedbackDto request)
        {

            return await _feedbackRepository.UpdateFeedback(id, request);
        }



        [HttpDelete("{id}")]
        public async Task DeleteFeedback(int id)
        {
            await _feedbackRepository.DeleteFeedback(id);

        }


    }
}
