using Microsoft.AspNetCore.Mvc;
using webapi.DTOs;
using webapi.Models;

namespace webapi.Repositories
{
    public interface IResultRepository
    {

        Task<ActionResult<List<Result>>> GetAll();
        Task<Result?> GetSingleResult(int id);
        Task<Result> AddResult(ResultDto request);
        Task<Result?> UpdateResult(int id, ResultDto request);
        Task DeleteResult(int id);
    }
}
