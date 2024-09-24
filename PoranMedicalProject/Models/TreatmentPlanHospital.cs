namespace PoranMedicalProject.Models
{
    public class TreatmentPlanHospital
    {
        // Junction Table for many-to-many relation between TreatmentPlan and Hospital
        public int TreatmentPlanID { get; set; }
        public TreatmentPlan TreatmentPlan { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Timestamp when the entry was created
        public DateTime UpdatedAt { get; set; } = DateTime.Now;  // Timestamp when the entry was last updated

        public int HospitalID { get; set; }
        public Hospital Hospital { get; set; }
    }

    //// dont need
}