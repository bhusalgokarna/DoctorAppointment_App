using DoctorAppointment.Models;
using System.ComponentModel.DataAnnotations;

namespace DoctorAppointment.ViewModels
{
    public enum Gender
    {
        Male, Female, Other
    }
    public class DoctorViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(20)]
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DOB { get; set; }
        public string UrlToPicture { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int HospitalInfoId { get; set; }
        public HospitalInfo HospitalInfo { get; set; }
        public ICollection<Appointment> Appointment { get; set; }
        public ICollection<Patient> Patients { get; set; }
        public string DepartmentName { get; set; }
        public string HospitalName { get; set; }
        
    }
}
