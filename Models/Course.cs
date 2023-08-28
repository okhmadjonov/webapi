namespace webapi.Models;

public class Course
{

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }

    public List<Student> Students { get; set; }
    public Teacher Teacher { get; set; }
    public HomeTask Task { get; set; }

}
