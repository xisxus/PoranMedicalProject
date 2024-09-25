using Microsoft.Extensions.Hosting;

namespace PoranMedicalProject.Models.Entites
{
    public class Patient
    {
        public int PatientID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string ContactInfo { get; set; }
        public string Passport { get; set; }
        public string PhotoUrl { get; set; }



        // One Patient can have many MedicalReports, Appointments, and Costs
        public ICollection<MedicalReport> MedicalReports { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Cost> Costs { get; set; }
        public ICollection<Patient> Patients { get; set; }

        // One Patient can have one Visa
        public Visa Visa { get; set; }

        public ICollection<PatientAttendent> PatientAttendents { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Timestamp when the entry was created
        public DateTime UpdatedAt { get; set; } = DateTime.Now;  // Timestamp when the entry was last updated



    }
}
