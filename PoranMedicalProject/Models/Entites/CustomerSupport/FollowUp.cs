using PoranMedicalProject.Models.Entites.PatientRelated;

namespace PoranMedicalProject.Models.Entites.CustomerSupport
{
    public class FollowUp
    {
        public int FollowUpID { get; set; }
        public int PatientID { get; set; }
        public DateTime FollowUpDate { get; set; }
        public string Notes { get; set; }
        public Patient Patient { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Timestamp when the entry was created
        public DateTime UpdatedAt { get; set; } = DateTime.Now;  // Timestamp when the entry was last updated
    }
}
