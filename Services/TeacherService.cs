using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.DTOs;
using webapi.Models;
using webapi.Repositories;

namespace webapi.Services
{
    public class TeacherService : ITeacherRepository
    {

        private readonly DataContext _dataContext;

        public TeacherService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Teacher> AddTeacher(TeacherDto request)
        {
            var teacher = request.Adapt<Teacher>();
            _dataContext.Teachers.Add(teacher);
            await _dataContext.SaveChangesAsync();
            return teacher;
        }

        public async Task DeleteTeacher(int id)
        {
            var teacher = await _dataContext.Teachers.FirstOrDefaultAsync(s => s.Id == id);
            _dataContext.Teachers.Remove(teacher);
            await _dataContext.SaveChangesAsync();

        }

        public async Task<ActionResult<List<Teacher>>> GetAll()
        {
            var teachers = await _dataContext.Teachers.ToListAsync();
            return teachers;
        }

        public async Task<Teacher?> GetSingleTeacher(int id)
        {
            var teacher = await _dataContext.Teachers.FirstOrDefaultAsync(s => s.Id == id);
            if (teacher == null) return null;
            return teacher;
        }

        public async Task<Teacher?> UpdateTeacher(int id, TeacherDto request)
        {

            var adaptedTeacher = request.Adapt<Teacher>();
            var teacher = await _dataContext.Teachers.FirstOrDefaultAsync(s => s.Id == id);

            teacher.Name = adaptedTeacher.Name;
            teacher.Email = adaptedTeacher.Email;
            teacher.Password = adaptedTeacher.Password;

            await _dataContext.SaveChangesAsync();
            return teacher;
        }
    }
}
