
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace DoctorAppointment.Models
{
    [Table("Doctor")]
    public class Doctor
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }      
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
		[MaxLength(100)]
		public string Email { get; set; }
		[MaxLength(50)]
		public string Phone { get; set; }
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        public string UrlToPicture { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }        
        public int HospitalInfoId { get; set; }
        public HospitalInfo HospitalInfo { get; set; }
        public ICollection<Appointment> Appointment { get; set; }
        public ICollection<Patient> Patients { get; set; }  
        public ICollection<DateSlot> DateSlots { get; set; }
       public ICollection<TimeSlot> TimeSlots { get; set; }
       
    }
}

