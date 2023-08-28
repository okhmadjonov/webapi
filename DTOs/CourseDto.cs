namespace webapi.DTOs
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        // public List<StudentDto> Students { get; set; }
        //  public TeacherDto Teacher { get; set; }
        //  public HomeTaskDto Task { get; set; }
    }
}
