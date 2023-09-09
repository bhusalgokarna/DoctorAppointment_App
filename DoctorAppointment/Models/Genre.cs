using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorAppointment.Models
{
    [Table("Genre")]
    public class Genre
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string Gender { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
        public ICollection<Patient> Patients { get; set; }
    }
}
