namespace DoctorAppointment.Models
{
    public class TimeSlot
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public String AvailAbleTime { get; set; }
    }
}
