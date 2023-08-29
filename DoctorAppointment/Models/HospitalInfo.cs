using DoctorAppointment.Models;
using Hospital.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Models
{
	public class HospitalInfo
	{
        public int Id { get; set; }

        [MaxLength(200)]
		public string Name { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public string UrlToPicture { get; set; }
        public ICollection<Contact> Contacts { get; set; }
        public ICollection<Doctor>Doctors { get; set; }
        public ICollection<Patient> Patients { get; set; }
        public ICollection<Department> Departments { get; set; }   
        
        

    }
}
