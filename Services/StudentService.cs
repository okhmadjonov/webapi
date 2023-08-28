using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.DTOs;
using webapi.Models;
using webapi.Repositories;

namespace webapi.Services
{
    public class StudentService : IStudentRepository
    {
        private readonly DataContext _dataContext;

        public StudentService(DataContext dataContext)
        {
            _dataContext = dataContext;

        }


        public async Task<ActionResult<List<Student>>> GetAll()
        {
            var students = await _dataContext.Students.ToListAsync();
            return students;
        }


        public async Task<Student?> GetSingleStudent(int id)
        {
            var student = await _dataContext.Students.FirstOrDefaultAsync(s => s.Id == id);
            if (student == null) return null;
            return student;
        }

        public async Task<Student> AddStudent(StudentDto request)
        {
            var student = request.Adapt<Student>();
            _dataContext.Students.Add(student);
            await _dataContext.SaveChangesAsync();
            return student;
        }

        public async Task<Student?> UpdateStudent(int id, StudentDto request)
        {
            var adaptedStudent = request.Adapt<Student>();
            var student = await _dataContext.Students.FirstOrDefaultAsync(s => s.Id == id);
            student.FirstName = adaptedStudent.FirstName;
            student.LastName = adaptedStudent.LastName;
            student.Email = adaptedStudent.Email;
            student.Password = adaptedStudent.Password;

            await _dataContext.SaveChangesAsync();
            return student;
        }



        public async Task DeleteStudent(int id)
        {
            var student = await _dataContext.Students.FirstOrDefaultAsync(s => s.Id == id);
            _dataContext.Students.Remove(student);
            await _dataContext.SaveChangesAsync();


        }




    }
}
