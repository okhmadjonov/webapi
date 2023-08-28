using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.DTOs;
using webapi.Models;
using webapi.Repositories;

namespace webapi.Services
{
    public class AnswerService : IAnswerRepository
    {

        private readonly DataContext _dataContext;

        public AnswerService(DataContext dataContext)
        {
            _dataContext = dataContext;

        }
        public async Task<ActionResult<List<Answer>>> GetAll()
        {
            var answers = await _dataContext.Answers.ToListAsync();
            return answers;
        }


        public async Task<Answer?> GetSingleAnswer(int id)
        {
            var answer = await _dataContext.Answers.FirstOrDefaultAsync(s => s.Id == id);
            if (answer == null) return null;
            return answer;
        }

        public async Task<Answer> AddAnswer(AnswerDto request)
        {
            var answer = request.Adapt<Answer>();
            _dataContext.Answers.Add(answer);
            await _dataContext.SaveChangesAsync();
            return answer;
        }

        public async Task<Answer?> UpdateAnswer(int id, AnswerDto request)
        {
            var adaptedAnswer = request.Adapt<Answer>();
            var answer = await _dataContext.Answers.FirstOrDefaultAsync(s => s.Id == id);
            answer.Description = adaptedAnswer.Description;


            await _dataContext.SaveChangesAsync();
            return answer;
        }



        public async Task DeleteAnswer(int id)
        {
            var answer = await _dataContext.Answers.FirstOrDefaultAsync(s => s.Id == id);
            _dataContext.Answers.Remove(answer);
            await _dataContext.SaveChangesAsync();


        }
    }
}
