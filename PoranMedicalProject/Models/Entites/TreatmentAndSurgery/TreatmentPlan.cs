using PoranMedicalProject.Models.Entites.Doctors;
using PoranMedicalProject.Models.Entites.HospitalRelated;
using PoranMedicalProject.Models.Entites.PatientRelated;



namespace PoranMedicalProject.Models.Entites.TreatmentAndSurgery
{
    public class TreatmentPlan
    {
        public int TreatmentPlanID { get; set; }
        public string RefNo { get; set; }
        public DateTime Date { get; set; } ///////////

        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }

        public ICollection<Surgery> Surgeries { get; set; }

        public int StayingHospitalDuration { get; set; }
        public int StayingOutsideDuration { get; set; }

        public string CostCurrency { get; set; }
        public double EstimatedCost { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now; // Timestamp when the entry was created
        public DateTime UpdatedAt { get; set; } = DateTime.Now;  // Timestamp when the entry was last updated





    }
}
