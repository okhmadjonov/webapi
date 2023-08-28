using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.DTOs;
using webapi.Models;
using webapi.Repositories;

namespace webapi.Services
{
    public class FeedbackService : IFeedbackRepository
    {


        private readonly DataContext _dataContext;

        public FeedbackService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public async Task<Feedback> AddFeedback(FeedbackDto request)
        {
            var feedback = request.Adapt<Feedback>();
            _dataContext.Feedbacks.Add(feedback);
            await _dataContext.SaveChangesAsync();
            return feedback;
        }

        public async Task DeleteFeedback(int id)
        {
            var feedback = await _dataContext.Feedbacks.FirstOrDefaultAsync(s => s.Id == id);
            _dataContext.Feedbacks.Remove(feedback);
            await _dataContext.SaveChangesAsync();

        }

        public async Task<ActionResult<List<Feedback>>> GetAll()
        {
            var feedbacks = await _dataContext.Feedbacks.ToListAsync();
            return feedbacks;
        }

        public async Task<Feedback?> GetSingleFeedback(int id)
        {
            var feedback = await _dataContext.Feedbacks.FirstOrDefaultAsync(s => s.Id == id);
            if (feedback == null) return null;
            return feedback;
        }

        public async Task<Feedback?> UpdateFeedback(int id, FeedbackDto request)
        {

            var adaptedFeedback = request.Adapt<Feedback>();
            var feedback = await _dataContext.Feedbacks.FirstOrDefaultAsync(s => s.Id == id);
            feedback.Message = adaptedFeedback.Message;


            await _dataContext.SaveChangesAsync();
            return feedback;
        }
    }
}
