using DoctorAppointment.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorAppointment.Models
{
    [Table("Appointment")]
	public class Appointment
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public DateTime CreatedDate = DateTime.Now;
        [MaxLength(200)]
        public string Description { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int DateSlotId { get; set; }
        public DateSlot DateSlot { get; set; }
        public int TimeSlotId { get; set; }
        public TimeSlot TimeSlot { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}