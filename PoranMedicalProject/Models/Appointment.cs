namespace PoranMedicalProject.Models
{
    public class Appointment
    {
        public int AppointmentID { get; set; }
        public int PatientID { get; set; }
        public Patient Patient { get; set; }

        public int HospitalID { get; set; }
        public Hospital Hospital { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Timestamp when the entry was created
        public DateTime UpdatedAt { get; set; } = DateTime.Now;  // Timestamp when the entry was last updated

        public DateTime AppointmentDate { get; set; }
        public string Description { get; set; }
    }
}