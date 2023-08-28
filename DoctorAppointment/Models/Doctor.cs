using Hospital.Model;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace DoctorAppointment.Models
{
    public class Doctor
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
       
    }
}
namespace Hospital.Model
{
    public enum Gender
    {
        Male, Female, Other
    }
}
