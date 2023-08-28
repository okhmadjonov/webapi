namespace webapi.Models
{
    public class Result
    {
        public int Id { get; set; }
        public string Message { get; set; }


        public int StudentId { get; set; }
        public Student Student { get; set; }

    }
}
