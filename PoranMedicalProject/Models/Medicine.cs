namespace PoranMedicalProject.Models
{
    public class Medicine
    {
        public int MedicineID { get; set; }
        public string MedicineName { get; set; }
        public decimal Price { get; set; }
        public DateTime OrderDate { get; set; }

        // Medicines can be associated with Patients (if needed)
        public ICollection<Patient> Patients { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Timestamp when the entry was created
        public DateTime UpdatedAt { get; set; } = DateTime.Now;  // Timestamp when the entry was last updated
    }
}
