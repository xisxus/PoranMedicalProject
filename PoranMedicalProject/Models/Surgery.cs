﻿namespace PoranMedicalProject.Models
{
    public class Surgery
    {
        public int SurgeryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int TreatmentPlanID { get; set; }
        public virtual TreatmentPlan TreatmentPlan { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Timestamp when the entry was created
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}