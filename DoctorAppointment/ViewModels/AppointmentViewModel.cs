using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DoctorAppointment.Models;


namespace DoctorAppointment.ViewModels
{
    public class AppointmentViewModel
    {
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

        public string DoctorName { get; set; }
        public string PatientName { get; set; }
        public string Bookeddate { get; set; }
        public string BookedTime { get; set; }

    }
}
