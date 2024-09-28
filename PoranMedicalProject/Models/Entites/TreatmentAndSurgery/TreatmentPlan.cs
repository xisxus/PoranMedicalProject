using PoranMedicalProject.Models.Entites.Doctors;
using PoranMedicalProject.Models.Entites.HospitalRelated;
using PoranMedicalProject.Models.Entites.PatientRelated;
using PoranMedicalProject.Models.Entites.TicketAndVisa;
using System.ComponentModel.DataAnnotations.Schema;



namespace PoranMedicalProject.Models.Entites.TreatmentAndSurgery
{
    public class TreatmentPlan
    {
        public int TreatmentPlanID { get; set; }
        public string RefNo { get; set; }
        public DateTime Date { get; set; }

        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }

        [ForeignKey("Hospital")]
        public int HospitalId { get; set; }
        public virtual Hospital Hospital { get; set; }

        public ICollection<Surgery> Surgeries { get; set; }

        public int StayingHospitalDuration { get; set; }
        public int StayingOutsideDuration { get; set; }

        public string CostCurrency { get; set; }
        public double EstimatedCost { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now; // Timestamp when the entry was created
        public DateTime UpdatedAt { get; set; } = DateTime.Now;  // Timestamp when the entry was last updated

        public ICollection<VisaApply> VisaApplies { get; set; }


        [ForeignKey("ResidenceDoctor")]
        public int ResidenceDoctorId { get; set; }
        public virtual Doctor ResidenceDoctor { get; set; }


        [ForeignKey("ResidenceHospital")]
        public int ResidenceHospitalId { get; set; }
        public virtual Hospital ResidenceHospital { get; set; }


    }
}
