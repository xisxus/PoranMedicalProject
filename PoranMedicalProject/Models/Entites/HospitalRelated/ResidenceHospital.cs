using PoranMedicalProject.Models.Entites.Doctors;
using PoranMedicalProject.Models.Entites.TreatmentAndSurgery;

namespace PoranMedicalProject.Models.Entites.HospitalRelated
{
    public class ResidenceHospital
    {
        public int ResidenceHospitalId { get; set; }
        public string HospitalName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string? PhotoUrl { get; set; }
        public string? Logo { get; set; }






        //public ICollection<Appointment> Appointments { get; set; }

        //public ICollection<HospitalFacilities> HospitalFacilities { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Timestamp when the entry was created
        public DateTime UpdatedAt { get; set; } = DateTime.Now;  // Timestamp when the entry was last updated
        public ICollection<ResidenceDoctor> ResidenceDoctors { get; set; }

        public ICollection<TreatmentPlan> TreatmentsPlans { get; set; }

    }
}
