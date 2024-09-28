namespace PoranMedicalProject.Models.OutputModel
{
    public class DoctorExperienceOutputModel
    {
        public int DoctorExperienceId { get; set; }
        public string ExpTitle { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}