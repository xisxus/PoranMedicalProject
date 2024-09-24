namespace PoranMedicalProject.Models
{
    public class GuidPatient
    {
        public int GuidPatientID { get; set; }

        public int GuidID { get; set; }
        public Guide Guide { get; set; }

        public int PatientID { get; set; }
        public Patient Patient { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Timestamp when the entry was created
        public DateTime UpdatedAt { get; set; } = DateTime.Now;  // Timestamp when the entry was last updated
    }
}