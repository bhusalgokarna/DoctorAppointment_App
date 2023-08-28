using DoctorAppointment.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Models
{
	public class Department
	{
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [ForeignKey(name: "HospitalInfo")]
        public int HospitalInfoId { get; set; }
        public HospitalInfo HospitalInfo { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
    }
}
