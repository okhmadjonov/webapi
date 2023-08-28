using Microsoft.AspNetCore.Mvc;
using webapi.DTOs;
using webapi.Models;

namespace webapi.Repositories
{
    public interface IAppointmentRepository
    {
        Task<ActionResult<List<Appointment>>> GetAll();
        Task<Appointment?> GetSingleAppointment(int id);
        Task<Appointment> AddAppointment(AppointmentDto request);
        Task<Appointment?> UpdateAppointment(int id, AppointmentDto request);
        Task DeleteAppointment(int id);
    }
}
