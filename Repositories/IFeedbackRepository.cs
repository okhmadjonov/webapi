using Microsoft.AspNetCore.Mvc;
using webapi.DTOs;
using webapi.Models;

namespace webapi.Repositories
{
    public interface IFeedbackRepository
    {

        Task<ActionResult<List<Feedback>>> GetAll();
        Task<Feedback?> GetSingleFeedback(int id);
        Task<Feedback> AddFeedback(FeedbackDto request);
        Task<Feedback?> UpdateFeedback(int id, FeedbackDto request);
        Task DeleteFeedback(int id);

    }
}
