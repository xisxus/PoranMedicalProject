using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace PoranMedicalProject.Models.DAL
{
    public class AppDbContext(DbContextOptions options) : IdentityDbContext<ApplicationUser>(options)
    {


        // DbSets for your entities
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<MedicalReport> MedicalReports { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<TreatmentPlan> TreatmentPlans { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Visa> Visas { get; set; }
        public DbSet<Cost> Costs { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Guide> Guids { get; set; }
        public DbSet<GuidPatient> GuidPatients { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<CustomerCallRequest> CustomerCallRequests { get; set; }
        public DbSet<CommissionAgent> CommissionAgents { get; set; }
        public DbSet<Commission> Commissions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<FollowUp> FollowUps { get; set; }
        public DbSet<Guide> Guides { get; set; }
        public DbSet<Insurance> Insurances { get; set; }

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

            modelBuilder.Entity<TreatmentPlanHospital>()
        .HasKey(tph => new { tph.TreatmentPlanID, tph.HospitalID });

            // Configuring relationships
            modelBuilder.Entity<TreatmentPlanHospital>()
                .HasOne(tph => tph.TreatmentPlan)
                .WithMany(tp => tp.TreatmentPlanHospitals)
                .HasForeignKey(tph => tph.TreatmentPlanID);

            modelBuilder.Entity<TreatmentPlanHospital>()
                .HasOne(tph => tph.Hospital)
                .WithMany(h => h.TreatmentPlanHospitals)
                .HasForeignKey(tph => tph.HospitalID);

            modelBuilder.Entity<CommissionAgent>()
                 .HasOne(ca => ca.ApplicationUser)
                 .WithMany()  // Assuming each ApplicationUser can have multiple CommissionAgents
                 .HasForeignKey(ca => ca.UserID);

            modelBuilder.Entity<GuidPatient>()
           .HasOne(gp => gp.Guide)
           .WithMany(g => g.GuidPatients)
           .HasForeignKey(gp => gp.GuidID);

            modelBuilder.Entity<GuidPatient>()
                .HasOne(gp => gp.Patient)
                .WithMany(p => p.GuidPatients)
                .HasForeignKey(gp => gp.PatientID);

            // Define relationships for Hospital and Appointment
            modelBuilder.Entity<Hospital>()
                .HasMany(h => h.Appointments)
                .WithOne(a => a.Hospital)
                .HasForeignKey(a => a.HospitalID);

            modelBuilder.Entity<Guide>()
        .HasKey(g => g.GuidID);
        }
    }
}
