using PoranMedicalProject.Models.Entites.PatientRelated;

namespace PoranMedicalProject.Models.Entites
{
    public class ActivityLog
    {
        public int ActivityLogID { get; set; } // Unique identifier for each activity log entry
        public int PatientID { get; set; } // Foreign key referencing the Patient table
        public string ActivityType { get; set; } // Type of activity (e.g., Arrival at Hotel, Check-up, etc.)
        public DateTime ActivityDate { get; set; } // Timestamp of when the activity occurred
        public string Description { get; set; } // Additional details about the activity
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Timestamp when the entry was created
        public DateTime UpdatedAt { get; set; } = DateTime.Now;  // Timestamp when the entry was last updated

        // Navigation property
        public virtual Patient Patient { get; set; } // Assuming you have a Patient class defined
    }

}
