using DoctorAppointment.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using DoctorAppointment.ViewModels;

namespace DoctorAppointment.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<HospitalInfo> HospitalInfo { get; set;}
        public DbSet<Genre> Genres { get; set; }
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
			builder.Entity<Appointment>()
				  .HasOne(a => a.DateSlot)
				  .WithMany(p => p.Appointments)
				  .OnDelete(DeleteBehavior.NoAction);

			builder.Entity<Appointment>()
				  .HasOne(a => a.TimeSlot)
				  .WithMany(p => p.Appointments)
				  .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Patient>()
                  .HasOne(a => a.Genre)
                  .WithMany(p => p.Patients)
                  .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Doctor>()
                 .HasOne(a => a.Genre)
                 .WithMany(p => p.Doctors)
                 .OnDelete(DeleteBehavior.NoAction);
          
            builder.Entity<DateSlot>()
                  .HasOne(ds => ds.Doctor)
                  .WithMany(d => d.DateSlots)
                  .HasForeignKey(ds => ds.DoctorId)
                  .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<TimeSlot>()
                 .HasOne(ds => ds.Doctor)
                 .WithMany(d => d.TimeSlots)
                 .HasForeignKey(ds => ds.DoctorId)
                 .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Patient>()
                .HasOne(a => a.HospitalInfo)
                .WithMany(p => p.Patients)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(builder);
            SeedRecords.SeedAddress(builder);
            SeedRecords.SeedContact(builder);
            SeedRecords.SeedGenre(builder);
            SeedRecords.SeedDepartment(builder);
            SeedRecords.SeedHospital(builder);
            SeedRecords.SeedDoctor(builder);
            SeedRecords.SeedPatient(builder);
            SeedRecords.SeedDate(builder);
            SeedRecords.SeedTime(builder);
            
        }
        
        //public DbSet<DoctorAppointment.ViewModels.AppointmentViewModel>? AppointmentViewModel { get; set; }
    }   
}