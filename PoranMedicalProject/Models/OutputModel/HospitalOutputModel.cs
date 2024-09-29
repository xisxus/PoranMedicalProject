namespace PoranMedicalProject.Models.OutputModel
{
    public class HospitalOutputModel
    {
        public int HospitalID { get; set; }
        public string HospitalName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PhotoUrl { get; set; }
        public string Logo { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<DoctorOutputModel> Doctors { get; set; }
        public ICollection<TreatmentPlanOutputModel> TreatmentPlans { get; set; }
        public ICollection<HospitalFacilitiesOutputModel> HospitalFacilities { get; set; }
        public ICollection<AppointmentOutputModel> Appointments { get; set; }
    }
}
