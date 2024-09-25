namespace PoranMedicalProject.Models.Entites
{
    public class Insurance
    {
        public int InsuranceID { get; set; }
        public string InsuranceProvider { get; set; }
        public string PolicyNumber { get; set; }
        public int PatientID { get; set; }
        public Patient Patient { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Timestamp when the entry was created
        public DateTime UpdatedAt { get; set; } = DateTime.Now;  // Timestamp when the entry was last updated
    }
}
