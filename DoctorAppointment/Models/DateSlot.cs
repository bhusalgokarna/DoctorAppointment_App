using DoctorAppointment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Models
{
    public class DateSlot
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public string AvailableDay { get; set; }
		public ICollection<Appointment> Appointments { get; set; }


	}
}

