using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorAppointment.Models
{
    [Table("Adress")]
    public class Address
    {
        public int Id { get; set; }
        [MaxLength(100)]
        [Display(Name ="Street Name")]
        public string StreetName { get; set; }
        [MaxLength(100)]
        public string City { get; set; }
        [MaxLength(100)]
        [Display(Name ="Post Code")]
        public string PostCode { get; set; }
        [MaxLength(100)]
        public string Country { get; set; }
        public HospitalInfo? HospitalInfo { get; set; }

    }
}
