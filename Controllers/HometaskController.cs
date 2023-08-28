using Microsoft.AspNetCore.Mvc;
using webapi.DTOs;
using webapi.Models;
using webapi.Services;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HometaskController : ControllerBase
    {

        private readonly HometaskService _hometaskService;

        public HometaskController(HometaskService hometaskService)
        {
            _hometaskService = hometaskService;
        }



        [HttpGet]
        public async Task<ActionResult<List<HomeTask>>> GetAll()
        {
            return Ok(await _hometaskService.GetAll());

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<HomeTask?>> GetSingleHometask(int id)
        {

            return Ok(await _hometaskService.GetSingleHometask(id));

        }


        [HttpPost]
        public async Task<ActionResult<HomeTask>> AddStudent(HomeTaskDto request)
        {
            return Ok(await _hometaskService.AddHometask(request));

        }


        [HttpPut("{id}")]
        public async Task<HomeTask?> UpdateHometask(int id, HomeTaskDto request)
        {

            return await _hometaskService.UpdateHometask(id, request);
        }



        [HttpDelete("{id}")]
        public async Task DeleteHometask(int id)
        {
            await _hometaskService.DeleteHometask(id);

        }




    }
}
