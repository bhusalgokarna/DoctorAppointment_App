using System.ComponentModel.DataAnnotations.Schema;
using Patient_Doctor_Appointment_App.Models;

namespace Patient_Doctor_Appointment_App.ViewModels
{
    public class AppointmentViewModel
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int DateSlotId { get; set; }
        [NotMapped]
        public DateSlot DateSlot { get; set; }
        public int TimeSlotId { get; set; }
        [NotMapped]
        public TimeSlot TimeSlot { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public string DoctorName { get; set; }
        public string PatientName { get; set; }
        public string Bookeddate { get; set; }
        public string BookedTime { get; set; }

    }
}
