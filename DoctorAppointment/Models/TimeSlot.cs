using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorAppointment.Models
{
    [Table("TimeSlot")]
    public class TimeSlot
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        [MaxLength(100)]
        public String AvailAbleTime { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
