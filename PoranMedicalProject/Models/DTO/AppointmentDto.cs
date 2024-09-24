namespace PoranMedicalProject.Models.DTO
{
    public class AppointmentDto
    {
        public int AppointmentID { get; set; }
        public int PatientID { get; set; }
        public int HospitalID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Description { get; set; }
    }
}
