using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.DTOs;
using webapi.Models;
using webapi.Repositories;

namespace webapi.Services
{
    public class HometaskService : IHometaskRepository
    {

        private readonly DataContext _dataContext;

        public HometaskService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<HomeTask> AddHometask(HomeTaskDto request)
        {
            var hometask = request.Adapt<HomeTask>();
            _dataContext.HomeTasks.Add(hometask);
            await _dataContext.SaveChangesAsync();
            return hometask;
        }

        public async Task DeleteHometask(int id)
        {
            var hometask = await _dataContext.HomeTasks.FirstOrDefaultAsync(s => s.Id == id);
            _dataContext.HomeTasks.Remove(hometask);
            await _dataContext.SaveChangesAsync();

        }

        public async Task<ActionResult<List<HomeTask>>> GetAll()
        {
            var hometasks = await _dataContext.HomeTasks.ToListAsync();
            return hometasks;
        }

        public async Task<HomeTask?> GetSingleHometask(int id)
        {
            var hometask = await _dataContext.HomeTasks.FirstOrDefaultAsync(s => s.Id == id);
            if (hometask == null) return null;
            return hometask;
        }

        public async Task<HomeTask?> UpdateHometask(int id, HomeTaskDto request)
        {

            var adaptedHometask = request.Adapt<HomeTask>();
            var hometask = await _dataContext.HomeTasks.FirstOrDefaultAsync(s => s.Id == id);
            hometask.Description = adaptedHometask.Description;


            await _dataContext.SaveChangesAsync();
            return hometask;
        }
    }
}
