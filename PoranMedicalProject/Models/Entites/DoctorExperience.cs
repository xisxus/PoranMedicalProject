﻿namespace PoranMedicalProject.Models.Entites
{
    public class DoctorExperience
    {
        public int DoctorExperienceId { get; set; }
        public string ExpTitle { get; set; }
        public string Description { get; set; }
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Timestamp when the entry was created
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}