﻿using DoctorAppointment.Models;
using System.ComponentModel.DataAnnotations;

namespace DoctorAppointment.Models
{
	public class Contact
	{
        public int Id { get; set; }
        public int HospitalId { get; set; }
        public HospitalInfo Hospital { get; set; }
        [MaxLength(100)]
        public string  Email { get; set; }
        [MaxLength(20)]
        public string Phone { get; set; }
        

    }
}