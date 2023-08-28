using DoctorAppointment.Models;
using DoctorAppointment.Repositories.Interfaces;
using Hospital.Model;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointment.Data
{
    public static class SeedRecords
    {
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
                    Gender = Gender.Male,
                    HospitalInfoId = 1,
                    DepartmentId = 2,
                    UrlToPicture = "Jasper.jpeg",
                    Email="Jasper@gmail.com",
                    Phone="+977-9856325689"
                }, new Doctor
                {
                    Id = 2,
                    Name = "Timerman",
                    Gender = Gender.Male,                    
                   HospitalInfoId = 1,                    
                    DepartmentId = 2,
                    UrlToPicture = "Timerman.jpeg",
                    Email = "Tiler@gmail.com",
                    Phone = "+977-9756325680"
                }, new Doctor
                {
                    Id = 3,
                    Name = "Umer",
                    Gender= Gender.Male,                  
                   HospitalInfoId = 1,                
                    DepartmentId = 1,
                    UrlToPicture = "Umer.jpeg",
                    Email = "Umr@outlook.be",
                    Phone = "+977-9656325254"

                }, new Doctor
                {
                    Id = 4,
                    Name = "Sneha",
                    Gender=Gender.Female,
                    HospitalInfoId = 1,
                    DepartmentId = 3,
                    UrlToPicture = "Sneha.jpeg",
                    Email = "Sneha@gmail.com",
                    Phone = "+977-9875325691"
                }, new Doctor
                {
                    Id = 5,
                    Name = "kristof",                    
                    Gender=Gender.Other,
                    HospitalInfoId = 1,                   
                    DepartmentId = 3,
                    UrlToPicture = "Kristof.jpeg",
                    Email = "Kristof@gmail.com",
                    Phone = "+977-1456325689"
                }, new Doctor
                {
                    Id = 6,
                    Name = "Tomar",
                    Gender=Gender.Male,
                    HospitalInfoId = 1,                    
                    DepartmentId = 4,
                    UrlToPicture = "Tomer.jpeg",
                    Email = "Tomer@Yahoomail.com",
                    Phone = "+977-9856325689"
                }, new Doctor
                {
                    Id = 7,
                    Name = "Iveta",
                    Gender=Gender.Female,
                    HospitalInfoId = 1,                    
                    DepartmentId = 5,
                    UrlToPicture = "Iveta.jpeg",
                    Email = "Iveta@gmail.com",
                    Phone = "+977-4856325632"
                }, new Doctor
                {
                    Id = 8,
                    Name = "Roland",
                    Gender =Gender.Male,
                    HospitalInfoId = 1,                  
                    DepartmentId = 6,
                    UrlToPicture = "Roland.jpeg",
                    Email = "Roland@gmail.com",
                    Phone = "+977-9756325645"
                }, new Doctor
                {
                    Id = 9,
                    Name = "Amanda",
                    Gender=Gender.Female,
                    HospitalInfoId = 1,                    
                    DepartmentId = 6,
                    UrlToPicture = "Amanda.jpeg",
                    Email = "Amanda@Yahoo.com",
                    Phone = "+977-9756325685"

                });


        }
        public static void SeedPatient(ModelBuilder model)
        {
            model.Entity<Patient>().HasData(
                new Patient
                {
                    Id=1,
                    Name="Gokarna",
                    Nationality="Nepalese",
                    Address="Bhddhanager 24,Kathmandu,Nepal",
                    DOB=new DateTime(1985,06,25),
                    Gender=Gender.Male,
                    DepartmentId=6
                }, new Patient
                {
                    Id = 2,
                    Name = "DGSon",
                    Nationality = "Nepalese",
                    Address = "MaitiGhar 124,Kathmandu,Nepal",
                    DOB = new DateTime(2002, 09, 10),
                    Gender = Gender.Male,
                    DepartmentId = 4
                }, new Patient
                {
                    Id = 3,
                    Name = "Paula",
                    Nationality = "Belgium",
                    Address = "Sinamangal 68,Kathmandu,Nepal",
                    DOB = new DateTime(2018, 04, 14),
                    Gender = Gender.Male,
                    DepartmentId = 3
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
            });
        }
        public static void SeedTime(ModelBuilder model)
        {

        }
       
    }
}
