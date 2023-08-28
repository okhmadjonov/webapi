using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.DTOs;
using webapi.Models;
using webapi.Repositories;

namespace webapi.Services
{
    public class CourseService : ICourseRepository
    {
        private readonly DataContext _dataContext;
        public CourseService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Course> AddCourse(CourseDto request)
        {
            var course = request.Adapt<Course>();
            _dataContext.Courses.Add(course);
            await _dataContext.SaveChangesAsync();
            return course;
        }

        public async Task<ActionResult<List<Course>>> GetAllCourses()
        {
            var courses = await _dataContext.Courses.ToListAsync();
            return courses;
        }

        public async Task<Course?> GetSingleCourse(int id)
        {
            var course = await _dataContext.Courses.FirstOrDefaultAsync(s => s.Id == id);
            if (course == null) return null;
            return course;
        }

        public async Task<Course?> UpdateCourse(int id, CourseDto request)
        {
            var adaptedCourse = request.Adapt<Course>();
            var course = await _dataContext.Courses.FirstOrDefaultAsync(s => s.Id == id);

            course.Name = adaptedCourse.Name;
            course.Description = adaptedCourse.Description;
            course.Price = adaptedCourse.Price;

            await _dataContext.SaveChangesAsync();
            return course;
        }


        public async Task DeleteCourse(int id)
        {
            var course = await _dataContext.Courses.FirstOrDefaultAsync(s => s.Id == id);
            _dataContext.Courses.Remove(course);
            await _dataContext.SaveChangesAsync();


        }



    }
}
