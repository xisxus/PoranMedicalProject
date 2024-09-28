namespace PoranMedicalProject.Models.Input_Models
{
    public class DoctorInputModel
    {
        public string DoctorName { get; set; }
        public string DoctorDesignation { get; set; }
        public int HospitalID { get; set; }
        public List<int> QualificationIds { get; set; }
        public List<int> ExperienceIds { get; set; }
    }
}
