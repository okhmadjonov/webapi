using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Data
{
    public class DataContext : DbContext
    {



        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }
        private const string CONNECTION_STRING = "Host=localhost;Port=5432;" +
               "Username=postgres;" +
               "Password=root;" +
               "Database=webapi";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(CONNECTION_STRING);
        }


        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<HomeTask> HomeTasks { get; set; }



    }
}
