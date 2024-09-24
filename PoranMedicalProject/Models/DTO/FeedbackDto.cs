namespace PoranMedicalProject.Models.DTO
{
    public class FeedbackDto
    {
        public int FeedbackID { get; set; }
        public int PatientID { get; set; }
        public int HospitalID { get; set; }
        public string Comments { get; set; }
        public int Rating { get; set; }
    }

}
