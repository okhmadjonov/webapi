namespace webapi.Models;

public class Feedback
{
    public int Id { get; set; }
    public string Message { get; set; }

    public int Studentid { get; set; }
    public Student Student { get; set; }

}
