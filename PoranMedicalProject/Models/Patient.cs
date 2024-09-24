﻿using Microsoft.Extensions.Hosting;

namespace PoranMedicalProject.Models
{
    public class Patient
    {
        public int PatientID { get; set; }
        public string Name { get; set; }
        public string ContactInfo { get; set; }
        public string Passport { get; set; }
        public string PhotoUrl { get; set; }



        // One Patient can have many MedicalReports, Appointments, and Costs
        public ICollection<MedicalReport> MedicalReports { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Cost> Costs { get; set; }

        // One Patient can have one Visa
        public Visa Visa { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Timestamp when the entry was created
        public DateTime UpdatedAt { get; set; } = DateTime.Now;  // Timestamp when the entry was last updated

        // One Patient can have many GuidPatient records
        public ICollection<GuidPatient> GuidPatients { get; set; }
    }
}
