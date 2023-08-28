using Microsoft.AspNetCore.Mvc;
using webapi.DTOs;
using webapi.Models;

namespace webapi.Repositories
{
    public interface IStudentRepository
    {
        Task<ActionResult<List<Student>>> GetAll();
        Task<Student?> GetSingleStudent(int id);
        Task<Student> AddStudent(StudentDto request);
        Task<Student?> UpdateStudent(int id, StudentDto request);
        Task DeleteStudent(int id);
    }
}
