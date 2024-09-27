using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PoranMedicalProject.Models.Entites;
using PoranMedicalProject.Models.Entites.CommisionAgent;
using PoranMedicalProject.Models.Entites.CustomerSupport;
using PoranMedicalProject.Models.Entites.Doctors;
using PoranMedicalProject.Models.Entites.EmployeeAndUser;
using PoranMedicalProject.Models.Entites.GuideRelated;
using PoranMedicalProject.Models.Entites.HospitalRelated;
using PoranMedicalProject.Models.Entites.LogAndComplain;
using PoranMedicalProject.Models.Entites.PatientRelated;
using PoranMedicalProject.Models.Entites.TicketAndVisa;
using PoranMedicalProject.Models.Entites.TreatmentAndSurgery;
using System;

namespace PoranMedicalProject.Models.DAL
{
    public class AppDbContext(DbContextOptions options) : IdentityDbContext<ApplicationUser>(options)
    {


        // DbSets for your entities
        public DbSet<ActivityLog> ActivityLogs { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Cost> Costs { get; set; }
        public DbSet<CustomerCallRequest> CustomerCallRequests { get; set; }
        public DbSet<CommissionAgent> CommissionAgents { get; set; }
        public DbSet<Commission> Commissions { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<DoctorExperience> DoctorExperiences { get; set; }
        public DbSet<Facilities> Facilities { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<FollowUp> FollowUps { get; set; }
        public DbSet<Guide> Guides { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<HospitalFacilities> HospitalFacilities { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Insurance> Insurances { get; set; }
       
        public DbSet<MedicalReport> MedicalReports { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientAttendent> patientAttendents { get; set; }
        public DbSet<PatientsTravel> PatientsTravels { get; set; }
        public DbSet<PatientFacilities> PatientFacilities { get; set; }
        public DbSet<DoctorQualification> DoctorQualifications { get; set; }
        public DbSet<Surgery> Surgeries { get; set; }
        public DbSet<Ticket> Tickets { get; set; }


        public DbSet<TreatmentPlan> TreatmentPlans { get; set; }
        
        public DbSet<Visa> Visas { get; set; }
        public DbSet<TeleMedichineRequest> TeleMedichineRequests { get; set; }
        public DbSet<Complain> Complains { get; set; }


       
       
       
       
    

        // Override the OnModelCreating method for any specific configurations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuring relationships, primary keys, etc.

            // Example: Configuring one-to-many relationship between CommissionAgent and Commission
            modelBuilder.Entity<Commission>()
                .HasOne(c => c.CommissionAgent)
                .WithMany(a => a.Commissions)
                .HasForeignKey(c => c.AgentID);

            // Example: Configuring one-to-many relationship between Patient and Appointment
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientID);

            // Example: Configuring one-to-many relationship between Patient and MedicalReport
            modelBuilder.Entity<MedicalReport>()
                .HasOne(mr => mr.Patient)
                .WithMany(p => p.MedicalReports)
                .HasForeignKey(mr => mr.PatientID);

            // Add any further custom configurations here

            modelBuilder.Entity<CommissionAgent>()
        .HasKey(ca => ca.AgentID);

            // Define relationships if necessary
            modelBuilder.Entity<CommissionAgent>()
                .HasOne(ca => ca.ApplicationUser)
                .WithMany()  // Assuming one user can be associated with multiple agents
                .HasForeignKey(ca => ca.UserID);

            modelBuilder.Entity<Commission>()
                .HasOne(c => c.CommissionAgent)
                .WithMany(ca => ca.Commissions)
                .HasForeignKey(c => c.AgentID);

           

            modelBuilder.Entity<CommissionAgent>()
                 .HasOne(ca => ca.ApplicationUser)
                 .WithMany()  // Assuming each ApplicationUser can have multiple CommissionAgents
                 .HasForeignKey(ca => ca.UserID);

          

            // Define relationships for Hospital and Appointment
            modelBuilder.Entity<Hospital>()
                .HasMany(h => h.Appointments)
                .WithOne(a => a.Hospital)
                .HasForeignKey(a => a.HospitalID);

            modelBuilder.Entity<Guide>()
        .HasKey(g => g.GuidID);

            modelBuilder.Entity<TreatmentPlan>()
           .HasOne(tp => tp.Hospital)
           .WithMany(h => h.TreatmentsPlans)
           .HasForeignKey(tp => tp.HospitalId)
           .OnDelete(DeleteBehavior.NoAction); // Specify 'Restrict' to avoid cascading deletes
        }
    }
}
