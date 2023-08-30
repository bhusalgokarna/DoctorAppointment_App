using DoctorAppointment.Models;
using DoctorAppointment.Repositories.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace DoctorAppointment.Data
{
    public static class SeedRecords
    {
        public  static void SeedGenre(ModelBuilder model)
        {
            model.Entity<Genre>().HasData(
                new Genre
                {
                    Id=1,
                    Gender="Male"
                }, new Genre
                {
                    Id = 2,
                    Gender = "Female"
                }, new Genre
                {
                    Id = 3,
                    Gender = "Other"
                });
        } 
        public static void SeedAddress(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().HasData(
                new Address
                {
                    Id = 1,
                    StreetName = "MilanChok",
                    City = "Sandikharkha",
                    PostCode = "2123",
                    Country = "Nepal"
                });                
        }
        public static void SeedHospital(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HospitalInfo>().HasData(
                
            new HospitalInfo
            {
                Id = 1,
                Name="Shandhikharkha Distric Hospital",
                AddressId = 1,
                UrlToPicture="Gangalal national heart center.jpeg",

            });
        }
        public static void SeedContact(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasData(

            new Contact
            {
                Id = 1,
                HospitalId = 1,
                Email="info@hospital.com.np",
                Phone="+97718544232565"

            });
        }
        public static void SeedDepartment(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department
                {
                    Id = 1,
                    HospitalInfoId=1,                  
                    Name = "Accident and Emergency Department (A & E)"

                }, new Department
                {
                    Id = 2,
                    HospitalInfoId = 1,
                    Name = "Intensive Care Unit (ICU)"
                }, new Department
                {
                    Id = 3,
                    HospitalInfoId = 1,
                    Name = "Pediatric"
                }, new Department
                {
                    Id = 4,
                    HospitalInfoId = 1,
                    Name = "Radiology"
                }, new Department
                {
                    Id = 5,
                    HospitalInfoId = 1,
                    Name = "General Surgery"
                }, new Department
                {
                    Id = 6,
                    HospitalInfoId = 1,
                    Name = "ENT"
                });
        }         
        public static void SeedDoctor(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = 1,
                    Name = "Jasper",  
                    GenreId =1,
                    HospitalInfoId = 1,
                    DepartmentId = 2,
                    UrlToPicture = "Jasper.jpeg",
                    Email="Jasper@gmail.com",
                    Phone="+977-9856325689"
                }, new Doctor
                {
                    Id = 2,
                    Name = "Timerman",
                    GenreId = 1,                    
                   HospitalInfoId = 1,                    
                    DepartmentId = 2,
                    UrlToPicture = "Timerman.jpeg",
                    Email = "Tiler@gmail.com",
                    Phone = "+977-9756325680"
                }, new Doctor
                {
                    Id = 3,
                    Name = "Umer",
                    GenreId = 1,                  
                   HospitalInfoId = 1,                
                    DepartmentId = 1,
                    UrlToPicture = "Umer.jpeg",
                    Email = "Umr@outlook.be",
                    Phone = "+977-9656325254"

                }, new Doctor
                {
                    Id = 4,
                    Name = "Sneha",
                    GenreId = 2,
                    HospitalInfoId = 1,
                    DepartmentId = 3,
                    UrlToPicture = "Sneha.jpeg",
                    Email = "Sneha@gmail.com",
                    Phone = "+977-9875325691"
                }, new Doctor
                {
                    Id = 5,
                    Name = "kristof",
                    GenreId = 3,
                    HospitalInfoId = 1,                   
                    DepartmentId = 3,
                    UrlToPicture = "Kristof.jpeg",
                    Email = "Kristof@gmail.com",
                    Phone = "+977-1456325689"
                }, new Doctor
                {
                    Id = 6,
                    Name = "Tomar",
                    GenreId = 1,
                    HospitalInfoId = 1,                    
                    DepartmentId = 4,
                    UrlToPicture = "Tomer.jpeg",
                    Email = "Tomer@Yahoomail.com",
                    Phone = "+977-9856325689"
                }, new Doctor
                {
                    Id = 7,
                    Name = "Iveta",
                    GenreId = 2,
                    HospitalInfoId = 1,                    
                    DepartmentId = 5,
                    UrlToPicture = "Iveta.jpeg",
                    Email = "Iveta@gmail.com",
                    Phone = "+977-4856325632"
                }, new Doctor
                {
                    Id = 8,
                    Name = "Roland",
                    GenreId = 1,
                    HospitalInfoId = 1,                  
                    DepartmentId = 6,
                    UrlToPicture = "Roland.jpeg",
                    Email = "Roland@gmail.com",
                    Phone = "+977-9756325645"
                }, new Doctor
                {
                    Id = 9,
                    Name = "Amanda",
                    GenreId = 2,
                    HospitalInfoId = 1,                    
                    DepartmentId = 6,
                    UrlToPicture = "Amanda.jpeg",
                    Email = "Amanda@Yahoo.com",
                    Phone = "+977-9756325685"

                });


        }     
        public static void SeedDate(ModelBuilder model)
        {
            model.Entity<DateSlot>().HasData(new DateSlot
            {
                Id = 1,
                DoctorId = 1,
                AvailableDay = "18.09.2023"
            }, new DateSlot
            {
                Id = 2,
                DoctorId = 2,
                AvailableDay = "18.09.2023"
            }, new DateSlot
            {
                Id = 3,
                DoctorId = 3,
                AvailableDay = "18.09.2023"
            }, new DateSlot
            {
                Id = 4,
                DoctorId = 4,
                AvailableDay = "18.09.2023"
            }, new DateSlot
            {
                Id = 5,
                DoctorId = 5,
                AvailableDay = "18.09.2023"
            },new DateSlot
            {
                Id = 6,
                DoctorId = 6,
                AvailableDay = "19.09.2023"
            }, new DateSlot
            {
                Id = 7,
                DoctorId = 7,
                AvailableDay = "19.09.2023"
            },new DateSlot
            {
                Id = 8,
                DoctorId = 1,
                AvailableDay = "19.09.2023"
            }, new DateSlot
            {
                Id = 9,
                DoctorId = 1,
                AvailableDay = "20.09.2023"
            }, new DateSlot
            {
                Id = 10,
                DoctorId = 2,
                AvailableDay = "19.09.2023"
            }, new DateSlot
            {
                Id = 11,
                DoctorId = 3,
                AvailableDay = "18.09.2023"
            }, new DateSlot
            {
                Id = 12,
                DoctorId =4,
                AvailableDay = "19.09.2023"
            }, new DateSlot
            {
                Id = 13,
                DoctorId = 5,
                AvailableDay = "19.09.2023"
            }, new DateSlot
            {
                Id = 14,
                DoctorId = 6,
                AvailableDay = "20.09.2023"
            }, new DateSlot
            {
                Id = 15,
                DoctorId =7,
                AvailableDay = "20.09.2023"
            }, new DateSlot
            {
                Id = 16,
                DoctorId = 8,
                AvailableDay = "18.09.2023"
            }, new DateSlot
            {
                Id = 17,
                DoctorId = 8,
                AvailableDay = "18.09.2023"
            }, new DateSlot
            {
                Id = 18,
                DoctorId = 9,
                AvailableDay = "18.09.2023"
            }, new DateSlot
            {
                Id = 19,
                DoctorId = 9,
                AvailableDay = "20.09.2023"
            }, new DateSlot
            {
                Id = 20,
                DoctorId = 6,
                AvailableDay = "21.09.2023"
            });
        }
        public static void SeedTime(ModelBuilder model)
        {
            model.Entity<TimeSlot>().HasData(
                new TimeSlot
                {
                    Id = 1,
                    DoctorId = 1,
                    AvailAbleTime = "9 AM"
                }, new TimeSlot
                {
                    Id = 2,
                    DoctorId = 1,
                    AvailAbleTime = "10 AM"
                }, new TimeSlot
                {
                    Id = 3,
                    DoctorId = 1,
                    AvailAbleTime = "11 AM"
                }, new TimeSlot
                {
                    Id = 4,
                    DoctorId = 1,
                    AvailAbleTime = "12 AM"
                }, new TimeSlot
                {
                    Id = 5,
                    DoctorId = 2,
                    AvailAbleTime = "13 PM"
                }, new TimeSlot
                {
                    Id = 6,
                    DoctorId = 2,
                    AvailAbleTime = "14 PM"
                }, new TimeSlot
                {
                    Id = 7,
                    DoctorId = 2,
                    AvailAbleTime = "15 PM"
                }, new TimeSlot
                {
                    Id = 8,
                    DoctorId = 2,
                    AvailAbleTime = "16 PM"
                }, new TimeSlot
                {
                    Id = 9,
                    DoctorId = 3,
                    AvailAbleTime = "17 PM"
                }, new TimeSlot
                {
                    Id = 10,
                    DoctorId = 3,
                    AvailAbleTime = "18 PM"
                }, new TimeSlot
                {
                    Id = 11,
                    DoctorId = 3,
                    AvailAbleTime = "19 PM"
                }, new TimeSlot
                {
                    Id = 12,
                    DoctorId = 3,
                    AvailAbleTime = "20 PM"
                }, new TimeSlot
                {
                    Id = 13,
                    DoctorId = 4,
                    AvailAbleTime = "9 AM"
                }, new TimeSlot
                {
                    Id = 14,
                    DoctorId = 4,
                    AvailAbleTime = "10 AM"
                }, new TimeSlot
                {
                    Id = 15,
                    DoctorId = 4,
                    AvailAbleTime = "11 AM"
                }, new TimeSlot
                {
                    Id = 16,
                    DoctorId = 4,
                    AvailAbleTime = "12 AM"
                }, new TimeSlot
                {
                    Id = 17,
                    DoctorId = 5,
                    AvailAbleTime = "13 PM"
                }, new TimeSlot
                {
                    Id = 18,
                    DoctorId = 5,
                    AvailAbleTime = "14 PM"
                }, new TimeSlot
                {
                    Id = 19,
                    DoctorId = 5,
                    AvailAbleTime = "15 PM"
                }, new TimeSlot
                {
                    Id = 20,
                    DoctorId = 5,
                    AvailAbleTime = "16 PM"
                }, new TimeSlot
                {
                    Id = 21,
                    DoctorId = 6,
                    AvailAbleTime = "17 PM"
                }, new TimeSlot
                {
                    Id = 22,
                    DoctorId = 6,
                    AvailAbleTime = "18 PM"
                }, new TimeSlot
                {
                    Id = 23,
                    DoctorId = 6,
                    AvailAbleTime = "19 PM"
                }, new TimeSlot
                {
                    Id = 24,
                    DoctorId = 6,
                    AvailAbleTime = "20 PM"
                }, new TimeSlot
                {
                    Id = 25,
                    DoctorId = 7,
                    AvailAbleTime = "9 AM"
                }, new TimeSlot
                {
                    Id = 26,
                    DoctorId = 7,
                    AvailAbleTime = "10 AM"
                }, new TimeSlot
                {
                    Id = 27,
                    DoctorId = 7,
                    AvailAbleTime = "11 AM"
                }, new TimeSlot
                {
                    Id = 28,
                    DoctorId = 7,
                    AvailAbleTime = "12 AM"
                }, new TimeSlot
                {
                    Id = 29,
                    DoctorId = 8,
                    AvailAbleTime = "13 PM"
                }, new TimeSlot
                {
                    Id = 30,
                    DoctorId = 8,
                    AvailAbleTime = "14 PM"
                }, new TimeSlot
                {
                    Id = 31,
                    DoctorId = 8,
                    AvailAbleTime = "15 PM"
                }, new TimeSlot
                {
                    Id = 32,
                    DoctorId = 8,
                    AvailAbleTime = "16 PM"
                }, new TimeSlot
                {
                    Id = 33,
                    DoctorId = 9,
                    AvailAbleTime = "17 PM"
                }, new TimeSlot
                {
                    Id = 34,
                    DoctorId = 9,
                    AvailAbleTime = "18 PM"
                }, new TimeSlot
                {
                    Id = 35,
                    DoctorId = 9,
                    AvailAbleTime = "19 PM"
                }, new TimeSlot
                {
                    Id = 36,
                    DoctorId = 9,
                    AvailAbleTime = "20 PM"
                });
        }
		public static void SeedPatient(ModelBuilder model)
		{
			model.Entity<Patient>().HasData(
				new Patient
				{
					Id = 1,
					Name = "Gokarna",
					Nationality = "Nepalese",
					Address = "Bhddhanager 24,Kathmandu,Nepal",
					DOB = new DateTime(1985, 06, 25),
                    GenreId = 1,
					DepartmentId = 6,
					DoctorId = 1,
					HospilInfoId = 1,
				}, new Patient
				{
					Id = 2,
					Name = "DGSon",
					Nationality = "Nepalese",
					Address = "MaitiGhar 124,Kathmandu,Nepal",
					DOB = new DateTime(2002, 09, 10),
                    GenreId = 1,
					DepartmentId = 4,
					DoctorId = 2,
					HospilInfoId = 1,

				}, new Patient
				{
					Id = 3,
					Name = "Paula",
					Nationality = "Belgium",
					Address = "Sinamangal 68,Kathmandu,Nepal",
					DOB = new DateTime(2018, 04, 14),
                    GenreId = 1,
					DepartmentId = 3,
					DoctorId = 3,
					HospilInfoId = 1,
				}, new Patient
				{
					Id = 4,
					Name = "Paula",
					Nationality = "Belgium",
					Address = "Sinamangal 68,Kathmandu,Nepal",
					DOB = new DateTime(2018, 04, 14),
                    GenreId = 2,
					DepartmentId = 3,
					DoctorId = 4,
					HospilInfoId = 1,
				}, new Patient
				{
					Id = 5,
					Name = "DGSon",
					Nationality = "Nepalese",
					Address = "MaitiGhar 124,Kathmandu,Nepal",
					DOB = new DateTime(2002, 09, 10),
                    GenreId = 1,
					DepartmentId = 4,
					DoctorId = 5,
					HospilInfoId = 1,

				}, new Patient
				{
					Id = 6,
					Name = "Gokarna",
					Nationality = "Nepalese",
					Address = "Bhddhanager 24,Kathmandu,Nepal",
					DOB = new DateTime(1985, 06, 25),
                    GenreId = 1,
					DepartmentId = 6,
					DoctorId = 6,
					HospilInfoId = 1,
				}, new Patient
				{
					Id = 7,
					Name = "Kenan",
					Nationality = "Belgie",
					Address = "NieuweStraat 120, Gent,Belgium",
					DOB = new DateTime(1965, 04, 25),
                    GenreId = 1,
					DepartmentId = 4,
					DoctorId = 7,
					HospilInfoId = 1,
				}, new Patient
				{
					Id = 8,
					Name = "Anu",
					Nationality = "Indian",
					Address = "Donderlieuw 121,Belgium",
					DOB = new DateTime(1994, 04, 25),
                    GenreId = 2,
					DepartmentId = 3,
					DoctorId = 8,
					HospilInfoId = 1,
				}, new Patient
				{
					Id = 9,
					Name = "Sabrina",
					Nationality = "Belgie",
					Address = "GroteMarkt 220, Brussel,Belgium",
					DOB = new DateTime(1980, 04, 25),
                    GenreId = 2,
					DepartmentId = 3,
					DoctorId = 9,
					HospilInfoId = 1,
				}, new Patient
				{
					Id = 10,
					Name = "Rufat",
					Nationality = "Azerbizan",
					Address = "GentSeesteenweg 120, Gent,Belgium",
					DOB = new DateTime(1985, 04, 12),
                    GenreId = 1,
					DepartmentId = 4,
					DoctorId = 1,
					HospilInfoId = 1,
				}, new Patient
				{
					Id = 11,
					Name = "Jonas",
					Nationality = "Belgie",
					Address = "Mechanlenlaan 85, Mechelen,Belgium",
					DOB = new DateTime(1999, 04, 25),
                    GenreId = 1,
					DepartmentId = 2,
					DoctorId = 2,
					HospilInfoId = 1,
				}, new Patient
				{
					Id = 12,
					Name = "Ahmed",
					Nationality = "Belgie",
					Address = "Grotelaan 45, Brussels,Belgium",
					DOB = new DateTime(1997, 04, 25),
                    GenreId = 1,
					DepartmentId = 2,
					DoctorId = 3,
					HospilInfoId = 1,
				}, new Patient
				{
					Id = 13,
					Name = "Arijs",
					Nationality = "Belgie",
					Address = "Zuidstation 36, Brussels,Belgium",
					DOB = new DateTime(1997, 04, 25),
                    GenreId = 2,
					DepartmentId = 1,
					DoctorId = 4,
					HospilInfoId = 1,
				}, new Patient
				{
					Id = 14,
					Name = "Madalina",
					Nationality = "Romania",
					Address = "Tournailaan 45, Tournai,Belgium",
					DOB = new DateTime(1991, 04, 25),
                    GenreId = 2,
					DepartmentId = 5,
					DoctorId = 5,
					HospilInfoId = 1,
				}, new Patient
				{
					Id = 15,
					Name = "Fida",
					Nationality = "Turkia",
					Address = "Leuvenlaan 45, Leuven,Belgium",
					DOB = new DateTime(1999, 04, 23),
                    GenreId = 1,
					DepartmentId = 2,
					DoctorId = 6,
					HospilInfoId = 1,
				}, new Patient
				{
					Id = 16,
					Name = "Mohamad",
					Nationality = "Marrokko",
					Address = "Molenbeeklaan 150, Brussels,Belgium",
					DOB = new DateTime(1997, 04, 14),
                    GenreId = 1,
					DepartmentId = 2,
					DoctorId = 7,
					HospilInfoId = 1,
				}, new Patient
				{
					Id = 17,
					Name = "Amanda",
					Nationality = "Belgie",
					Address = "Oplinter 102, Tienen,Belgium",
					DOB = new DateTime(2008, 09, 25),
                    GenreId = 2,
					DepartmentId = 3,
					DoctorId = 8,
					HospilInfoId = 1,
				}, new Patient
				{
					Id = 18,
					Name = "Rolis",
					Nationality = "Belgie",
					Address = "DiestSesteenweg 111, Diest,Belgium",
					DOB = new DateTime(2012, 06, 17),
                    GenreId = 1,
					DepartmentId = 5,
					DoctorId = 9,
					HospilInfoId = 1,
				});
		}
       
	}
}
