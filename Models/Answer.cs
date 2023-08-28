namespace webapi.Models;

public class Answer
{
    public int Id { get; set; }
    public string Description { get; set; }


    public int StudentId { get; set; }
    public Student Student { get; set; }

}
