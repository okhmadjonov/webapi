using Microsoft.AspNetCore.Mvc;
using webapi.DTOs;
using webapi.Models;

namespace webapi.Repositories
{
    public interface IHometaskRepository
    {

        Task<ActionResult<List<HomeTask>>> GetAll();
        Task<HomeTask?> GetSingleHometask(int id);
        Task<HomeTask> AddHometask(HomeTaskDto request);
        Task<HomeTask?> UpdateHometask(int id, HomeTaskDto request);
        Task DeleteHometask(int id);
    }
}
