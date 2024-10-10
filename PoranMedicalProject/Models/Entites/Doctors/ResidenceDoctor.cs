using PoranMedicalProject.Models.Entites.HospitalRelated;
using PoranMedicalProject.Models.Entites.TreatmentAndSurgery;

namespace PoranMedicalProject.Models.Entites.Doctors
{
    public class ResidenceDoctor
    {
        public int ResidenceDoctorId { get; set; }
        public string DoctorName { get; set; }
        public string DoctorDasignation { get; set; }
        public string ImageUrl { get; set; }
        public int ResidenceHospitalID { get; set; }
        public virtual ResidenceHospital ResidenceHospital { get; set; }

        //public ICollection<DoctorQualification> DoctorQualifications { get; set; }
        //public ICollection<DoctorExperience> DoctorExperiences { get; set; }
        public ICollection<TreatmentPlan> TreatmentPlans { get; set; }


        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}
