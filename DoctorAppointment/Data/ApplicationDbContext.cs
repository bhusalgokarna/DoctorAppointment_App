using DoctorAppointment.Models;
using Hospital.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace DoctorAppointment.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<HospitalInfo> HospitalInfo { get; set;}
        public DbSet<Doctor>Doctors { get; set;}
        public DbSet<Patient> Patients { get; set;}
        public DbSet<Appointment> Appointments { get; set;}
        public DbSet<Department>Departments { get; set;}
        public DbSet<Address> Address { get; set;}
        public DbSet<Contact>Contacts { get; set;}
        public DbSet<DateSlot> DateSlots { get; set;}
        public DbSet<TimeSlot> TimeSlots { get; set;}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Doctor>()
                .HasOne(a => a.HospitalInfo)
                .WithMany(p => p.Doctors)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(p => p.Appointment)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Doctor>()
                  .HasOne(a => a.Department)
                  .WithMany(p => p.Doctors)
                  .OnDelete(DeleteBehavior.NoAction);
            
                

            base.OnModelCreating(builder);
            SeedRecords.SeedAddress(builder);
            SeedRecords.SeedDepartment(builder);
            SeedRecords.SeedHospital(builder);
            SeedRecords.SeedDoctor(builder);
            SeedRecords.SeedPatient(builder);
        }
    }   
}