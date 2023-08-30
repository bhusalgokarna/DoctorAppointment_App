
using System.ComponentModel.DataAnnotations;

namespace DoctorAppointment.Models
{
    public class Patient
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public int GenreId { get; set; }
        [MaxLength(20)]
        public Genre Genre { get; set; }
        [MaxLength(50)]
        public string Nationality { get; set; }
        [MaxLength(150)]
        public string Address { get; set; }
        public DateTime DOB { get; set; }
        public int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
        public int HospilInfoId { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<Appointment> Appointments { get; set; }

    }
}
