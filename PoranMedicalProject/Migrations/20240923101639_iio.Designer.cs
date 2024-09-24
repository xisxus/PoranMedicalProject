﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PoranMedicalProject.Models.DAL;

#nullable disable

namespace PoranMedicalProject.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240923101639_iio")]
    partial class iio
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("PoranMedicalProject.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("PoranMedicalProject.Models.Appointment", b =>
                {
                    b.Property<int>("AppointmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AppointmentID"));

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HospitalID")
                        .HasColumnType("int");

                    b.Property<int>("PatientID")
                        .HasColumnType("int");

                    b.HasKey("AppointmentID");

                    b.HasIndex("HospitalID");

                    b.HasIndex("PatientID");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("PoranMedicalProject.Models.Commission", b =>
                {
                    b.Property<int>("CommissionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommissionID"));

                    b.Property<int>("AgentID")
                        .HasColumnType("int");

                    b.Property<decimal>("CommissionAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DateEarned")
                        .HasColumnType("datetime2");

                    b.Property<int>("PatientID")
                        .HasColumnType("int");

                    b.HasKey("CommissionID");

                    b.HasIndex("AgentID");

                    b.HasIndex("PatientID");

                    b.ToTable("Commissions");
                });

            modelBuilder.Entity("PoranMedicalProject.Models.CommissionAgent", b =>
                {
                    b.Property<int>("AgentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AgentID"));

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("CommissionRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalCommissionEarned")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AgentID");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("UserID");

                    b.ToTable("CommissionAgents");
                });

            modelBuilder.Entity("PoranMedicalProject.Models.Cost", b =>
                {
                    b.Property<int>("CostID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CostID"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PatientID")
                        .HasColumnType("int");

                    b.Property<string>("ServiceType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CostID");

                    b.HasIndex("PatientID");

                    b.ToTable("Costs");
                });

            modelBuilder.Entity("PoranMedicalProject.Models.CustomerRequest", b =>
                {
                    b.Property<int>("CustomerRequestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerRequestID"));

                    b.Property<string>("MobileNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PatientID")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerRequestID");

                    b.HasIndex("PatientID");

                    b.ToTable("CustomerRequests");
                });

            modelBuilder.Entity("PoranMedicalProject.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeID"));

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("EmployeeID");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("PoranMedicalProject.Models.Guid", b =>
                {
                    b.Property<int>("GuidID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GuidID"));

                    b.Property<string>("GuidName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GuidID");

                    b.ToTable("Guids");
                });

            modelBuilder.Entity("PoranMedicalProject.Models.GuidPatient", b =>
                {
                    b.Property<int>("GuidPatientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GuidPatientID"));

                    b.Property<int>("GuidID")
                        .HasColumnType("int");

                    b.Property<int>("PatientID")
                        .HasColumnType("int");

                    b.HasKey("GuidPatientID");

                    b.HasIndex("GuidID");

                    b.HasIndex("PatientID");

                    b.ToTable("GuidPatients");
                });

            modelBuilder.Entity("PoranMedicalProject.Models.Hospital", b =>
                {
                    b.Property<int>("HospitalID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HospitalID"));

                    b.Property<string>("HospitalName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HospitalID");

                    b.ToTable("Hospitals");
                });

            modelBuilder.Entity("PoranMedicalProject.Models.Hotel", b =>
                {
                    b.Property<int>("HotelID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HotelID"));

                    b.Property<string>("HotelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("HotelID");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("PoranMedicalProject.Models.MedicalReport", b =>
                {
                    b.Property<int>("MedicalReportID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MedicalReportID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PatientID")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MedicalReportID");

                    b.HasIndex("PatientID");

                    b.ToTable("MedicalReports");
                });

            modelBuilder.Entity("PoranMedicalProject.Models.Medicine", b =>
                {
                    b.Property<int>("MedicineID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MedicineID"));

                    b.Property<string>("MedicineName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("MedicineID");

                    b.ToTable("Medicines");
                });

            modelBuilder.Entity("PoranMedicalProject.Models.Patient", b =>
                {
                    b.Property<int>("PatientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PatientID"));

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ContactInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HotelID")
                        .HasColumnType("int");

                    b.Property<int?>("MedicineID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Passport")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TicketID")
                        .HasColumnType("int");

                    b.HasKey("PatientID");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("HotelID");

                    b.HasIndex("MedicineID");

                    b.HasIndex("TicketID");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("PoranMedicalProject.Models.Ticket", b =>
                {
                    b.Property<int>("TicketID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TicketID"));

                    b.Property<decimal>("TicketPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("TicketID");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("PoranMedicalProject.Models.TreatmentPlan", b =>
                {
                    b.Property<int>("TreatmentPlanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TreatmentPlanID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TreatmentPlanID");

                    b.ToTable("TreatmentPlans");
                });

            modelBuilder.Entity("PoranMedicalProject.Models.TreatmentPlanHospital", b =>
                {
                    b.Property<int>("TreatmentPlanID")
                        .HasColumnType("int");

                    b.Property<int>("HospitalID")
                        .HasColumnType("int");

                    b.HasKey("TreatmentPlanID", "HospitalID");

                    b.HasIndex("HospitalID");

                    b.ToTable("TreatmentPlanHospital");
                });

            modelBuilder.Entity("PoranMedicalProject.Models.Visa", b =>
                {
                    b.Property<int>("VisaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VisaID"));

                    b.Property<int>("PatientID")
                        .HasColumnType("int");

                    b.Property<decimal>("ProcessingFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("VisaStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VisaID");

                    b.HasIndex("PatientID")
                        .IsUnique();

                    b.ToTable("Visas");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("PoranMedicalProject.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("PoranMedicalProject.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PoranMedicalProject.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("PoranMedicalProject.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PoranMedicalProject.Models.Appointment", b =>
                {
                    b.HasOne("PoranMedicalProject.Models.Hospital", "Hospital")
                        .WithMany("Appointments")
                        .HasForeignKey("HospitalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PoranMedicalProject.Models.Patient", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hospital");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("PoranMedicalProject.Models.Commission", b =>
                {
                    b.HasOne("PoranMedicalProject.Models.CommissionAgent", "CommissionAgent")
                        .WithMany("Commissions")
                        .HasForeignKey("AgentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PoranMedicalProject.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CommissionAgent");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("PoranMedicalProject.Models.CommissionAgent", b =>
                {
                    b.HasOne("PoranMedicalProject.Models.ApplicationUser", null)
                        .WithMany("CommissionAgents")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("PoranMedicalProject.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("PoranMedicalProject.Models.Cost", b =>
                {
                    b.HasOne("PoranMedicalProject.Models.Patient", "Patient")
                        .WithMany("Costs")
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("PoranMedicalProject.Models.CustomerRequest", b =>
                {
                    b.HasOne("PoranMedicalProject.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("PoranMedicalProject.Models.Employee", b =>
                {
                    b.HasOne("PoranMedicalProject.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("Employees")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("PoranMedicalProject.Models.GuidPatient", b =>
                {
                    b.HasOne("PoranMedicalProject.Models.Guid", "Guid")
                        .WithMany("GuidPatients")
                        .HasForeignKey("GuidID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PoranMedicalProject.Models.Patient", "Patient")
                        .WithMany("GuidPatients")
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guid");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("PoranMedicalProject.Models.MedicalReport", b =>
                {
                    b.HasOne("PoranMedicalProject.Models.Patient", "Patient")
                        .WithMany("MedicalReports")
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("PoranMedicalProject.Models.Patient", b =>
                {
                    b.HasOne("PoranMedicalProject.Models.ApplicationUser", null)
                        .WithMany("Patients")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("PoranMedicalProject.Models.Hotel", null)
                        .WithMany("Patients")
                        .HasForeignKey("HotelID");

                    b.HasOne("PoranMedicalProject.Models.Medicine", null)
                        .WithMany("Patients")
                        .HasForeignKey("MedicineID");

                    b.HasOne("PoranMedicalProject.Models.Ticket", null)
                        .WithMany("Patients")
                        .HasForeignKey("TicketID");
                });

            modelBuilder.Entity("PoranMedicalProject.Models.TreatmentPlanHospital", b =>
                {
                    b.HasOne("PoranMedicalProject.Models.Hospital", "Hospital")
                        .WithMany("TreatmentPlanHospitals")
                        .HasForeignKey("HospitalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PoranMedicalProject.Models.TreatmentPlan", "TreatmentPlan")
                        .WithMany("TreatmentPlanHospitals")
                        .HasForeignKey("TreatmentPlanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hospital");

                    b.Navigation("TreatmentPlan");
                });

            modelBuilder.Entity("PoranMedicalProject.Models.Visa", b =>
                {
                    b.HasOne("PoranMedicalProject.Models.Patient", "Patient")
                        .WithOne("Visa")
                        .HasForeignKey("PoranMedicalProject.Models.Visa", "PatientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("PoranMedicalProject.Models.ApplicationUser", b =>
                {
                    b.Navigation("CommissionAgents");

                    b.Navigation("Employees");

                    b.Navigation("Patients");
                });

            modelBuilder.Entity("PoranMedicalProject.Models.CommissionAgent", b =>
                {
                    b.Navigation("Commissions");
                });

            modelBuilder.Entity("PoranMedicalProject.Models.Guid", b =>
                {
                    b.Navigation("GuidPatients");
                });

            modelBuilder.Entity("PoranMedicalProject.Models.Hospital", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("TreatmentPlanHospitals");
                });

            modelBuilder.Entity("PoranMedicalProject.Models.Hotel", b =>
                {
                    b.Navigation("Patients");
                });

            modelBuilder.Entity("PoranMedicalProject.Models.Medicine", b =>
                {
                    b.Navigation("Patients");
                });

            modelBuilder.Entity("PoranMedicalProject.Models.Patient", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Costs");

                    b.Navigation("GuidPatients");

                    b.Navigation("MedicalReports");

                    b.Navigation("Visa")
                        .IsRequired();
                });

            modelBuilder.Entity("PoranMedicalProject.Models.Ticket", b =>
                {
                    b.Navigation("Patients");
                });

            modelBuilder.Entity("PoranMedicalProject.Models.TreatmentPlan", b =>
                {
                    b.Navigation("TreatmentPlanHospitals");
                });
#pragma warning restore 612, 618
        }
    }
}
