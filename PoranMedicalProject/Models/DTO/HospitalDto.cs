namespace PoranMedicalProject.Models.DTO
{
    public class HospitalDto
    {
        public int HospitalID { get; set; }
        public string HospitalName { get; set; }
        public string Location { get; set; }
        public ICollection<int> AppointmentIDs { get; set; }
        public ICollection<int> TreatmentPlanHospitalIDs { get; set; }
    }

}
