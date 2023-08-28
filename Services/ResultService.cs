using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.DTOs;
using webapi.Models;
using webapi.Repositories;

namespace webapi.Services
{
    public class ResultService : IResultRepository
    {

        private readonly DataContext _dataContext;

        public ResultService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }



        public async Task<Result> AddResult(ResultDto request)
        {
            var result = request.Adapt<Result>();
            _dataContext.Results.Add(result);
            await _dataContext.SaveChangesAsync();
            return result;
        }

        public async Task DeleteResult(int id)
        {
            var result = await _dataContext.Results.FirstOrDefaultAsync(s => s.Id == id);
            _dataContext.Results.Remove(result);
            await _dataContext.SaveChangesAsync();

        }

        public async Task<ActionResult<List<Result>>> GetAll()
        {
            var results = await _dataContext.Results.ToListAsync();
            return results;
        }

        public async Task<Result?> GetSingleResult(int id)
        {
            var result = await _dataContext.Results.FirstOrDefaultAsync(s => s.Id == id);
            if (result == null) return null;
            return result;
        }

        public async Task<Result?> UpdateResult(int id, ResultDto request)
        {

            var adaptedResult = request.Adapt<Result>();
            var result = await _dataContext.Results.FirstOrDefaultAsync(s => s.Id == id);
            result.Message = adaptedResult.Message;


            await _dataContext.SaveChangesAsync();
            return result;
        }
    }
}
