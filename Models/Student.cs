namespace webapi.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<Course> Courses { get; set; }
        public Answer Answer { get; set; }
        public Appointment Appointment { get; set; }
        public Result Result { get; set; }
        public Feedback Feedback { get; set; }

    }
}
