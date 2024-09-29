namespace PoranMedicalProject.Models.OutputModel
{
    public class DoctorOutputModel
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string DoctorDesignation { get; set; }
        public int HospitalID { get; set; }
        public string ImageUrl { get; set; }
        public List<DoctorQualificationOutputModel> Qualifications { get; set; }
        public List<DoctorExperienceOutputModel> Experiences { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
