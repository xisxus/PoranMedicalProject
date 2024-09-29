namespace PoranMedicalProject.Models.Input_Models
{
    public class DoctorInputModel
    {
        public string DoctorName { get; set; }
        public string DoctorDesignation { get; set; }
        public int HospitalID { get; set; }
        public IFormFile ImageFile { get; set; }
        public List<int> Qualifications { get; set; } 
        public List<int> Experiences { get; set; } 
    }

    public class QualificationInputModel
    {
        public string QualificationName { get; set; }
        public string QualificationDescription { get; set; }
    }

    public class ExperienceInputModel
    {
        public string ExpTitle { get; set; }
        public string Description { get; set; }
    }

    public class QualificationInputModel2
    {
        public List<QualificationInputModel> Qualifications { get; set; } = new List<QualificationInputModel>();
       
    }

    public class ExperienceInputModel2
    {
        public List<ExperienceInputModel> Experiences { get; set; } = new List<ExperienceInputModel>();
    }

}
