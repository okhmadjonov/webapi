namespace webapi.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string DayTime { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

    }
}
