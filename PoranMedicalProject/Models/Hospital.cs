namespace PoranMedicalProject.Models
{
    public class Hospital
    {
        public int HospitalID { get; set; }
        public string HospitalName { get; set; }
        public string Location { get; set; }
        



        // One Hospital can have many Appointments
        public ICollection<Appointment> Appointments { get; set; }

        // Many Hospitals can be part of many TreatmentPlans (many-to-many)
        public ICollection<TreatmentPlanHospital> TreatmentPlanHospitals { get; set; }
        public ICollection<HospitalPhoto> HospitalPhotos { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Timestamp when the entry was created
        public DateTime UpdatedAt { get; set; } = DateTime.Now;  // Timestamp when the entry was last updated
        public ICollection<Doctor> Doctors { get; set; }    
    }
}