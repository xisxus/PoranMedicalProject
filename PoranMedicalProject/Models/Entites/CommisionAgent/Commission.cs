﻿using PoranMedicalProject.Models.Entites.PatientRelated;

namespace PoranMedicalProject.Models.Entites.CommisionAgent
{
    public class Commission
    {
        public int CommissionID { get; set; }
        public int AgentID { get; set; }
        public CommissionAgent CommissionAgent { get; set; }

        public int PatientID { get; set; }
        public Patient Patient { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Timestamp when the entry was created
        public DateTime UpdatedAt { get; set; } = DateTime.Now;  // Timestamp when the entry was last updated

        public decimal CommissionAmount { get; set; }
        public DateTime DateEarned { get; set; }
    }
}
