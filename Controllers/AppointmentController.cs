using Microsoft.AspNetCore.Mvc;
using webapi.DTOs;
using webapi.Models;
using webapi.Repositories;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {

        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentController(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Appointment>>> GetAll()
        {
            return Ok(await _appointmentRepository.GetAll());

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment?>> GetSingleAppointment(int id)
        {

            return Ok(await _appointmentRepository.GetSingleAppointment(id));

        }


        [HttpPost("{id}")]
        public async Task<ActionResult<Appointment>> AddAppointment(int id, AppointmentDto request)
        {
            return Ok(await _appointmentRepository.AddAppointment(request));

        }


        [HttpPut("{id}")]
        public async Task<Appointment?> UpdateAppointment(int id, AppointmentDto request)
        {

            return await _appointmentRepository.UpdateAppointment(id, request);
        }



        [HttpDelete("{id}")]
        public async Task DeleteAppointment(int id)
        {
            await _appointmentRepository.DeleteAppointment(id);

        }

    }
}
