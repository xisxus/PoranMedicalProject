namespace PoranMedicalProject.Models.Entites
{
    public class Visa
    {
        public int VisaID { get; set; }
        public string VisaStatus { get; set; }
        public decimal ProcessingFee { get; set; }
        public int PatientID { get; set; }
        public Patient Patient { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Timestamp when the entry was created
        public DateTime UpdatedAt { get; set; } = DateTime.Now;  // Timestamp when the entry was last updated

    }
}
