using PoranMedicalProject.Models.Entites.HospitalRelated;
using PoranMedicalProject.Models.Entites.PatientRelated;

namespace PoranMedicalProject.Models.Entites.CustomerSupport
{
    public class Feedback
    {
        public int FeedbackID { get; set; }
        public int PatientID { get; set; }
        public int HospitalID { get; set; }
        public string Comments { get; set; }
        public int Rating { get; set; }  // e.g., from 1 to 5 stars
        public Patient Patient { get; set; }
        public Hospital Hospital { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Timestamp when the entry was created
        public DateTime UpdatedAt { get; set; } = DateTime.Now;  // Timestamp when the entry was last updated
    }
}
