namespace PoranMedicalProject.Models.OutputModel
{
    public class DoctorQualificationOutputModel
    {
        public int DoctorQualificationId { get; set; }
        public string QualificationName { get; set; }
        public string QualificationDescription { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}