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
    [Table("DateSlot")]
    public class DateSlot
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        [MaxLength(100)]
        public string AvailableDay { get; set; }
		public ICollection<Appointment> Appointments { get; set; }


	}
}

