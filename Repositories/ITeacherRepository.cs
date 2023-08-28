using Microsoft.AspNetCore.Mvc;
using webapi.DTOs;
using webapi.Models;

namespace webapi.Repositories
{
    public interface ITeacherRepository
    {
        Task<ActionResult<List<Teacher>>> GetAll();
        Task<Teacher?> GetSingleTeacher(int id);
        Task<Teacher> AddTeacher(TeacherDto request);
        Task<Teacher?> UpdateTeacher(int id, TeacherDto request);
        Task DeleteTeacher(int id);
    }
}
