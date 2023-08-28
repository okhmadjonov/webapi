using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.DTOs;
using webapi.Models;
using webapi.Repositories;

namespace webapi.Services
{
    public class AppointmentService : IAppointmentRepository
    {

        private readonly DataContext _dataContext;

        public AppointmentService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Appointment> AddAppointment(AppointmentDto request)
        {
            var appointment = request.Adapt<Appointment>();
            _dataContext.Appointments.Add(appointment);
            await _dataContext.SaveChangesAsync();
            return appointment;
        }

        public async Task DeleteAppointment(int id)
        {
            var appointment = await _dataContext.Appointments.FirstOrDefaultAsync(s => s.Id == id);
            _dataContext.Appointments.Remove(appointment);
            await _dataContext.SaveChangesAsync();

        }

        public async Task<ActionResult<List<Appointment>>> GetAll()
        {
            var appointments = await _dataContext.Appointments.ToListAsync();
            return appointments;
        }

        public async Task<Appointment?> GetSingleAppointment(int id)
        {
            var appointment = await _dataContext.Appointments.FirstOrDefaultAsync(s => s.Id == id);
            if (appointment == null) return null;
            return appointment;
        }

        public async Task<Appointment?> UpdateAppointment(int id, AppointmentDto request)
        {
            var adaptedAppointment = request.Adapt<Appointment>();
            var appointment = await _dataContext.Appointments.FirstOrDefaultAsync(s => s.Id == id);
            appointment.DayTime = adaptedAppointment.DayTime;


            await _dataContext.SaveChangesAsync();
            return appointment;
        }
    }
}
