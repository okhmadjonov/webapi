using Microsoft.AspNetCore.Mvc;
using webapi.DTOs;
using webapi.Models;

namespace webapi.Repositories
{
    public interface IAnswerRepository
    {


        Task<ActionResult<List<Answer>>> GetAll();
        Task<Answer?> GetSingleAnswer(int id);
        Task<Answer> AddAnswer(AnswerDto request);
        Task<Answer?> UpdateAnswer(int id, AnswerDto request);
        Task DeleteAnswer(int id);
    }
}
