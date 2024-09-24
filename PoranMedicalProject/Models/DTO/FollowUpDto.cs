namespace PoranMedicalProject.Models.DTO
{
    public class FollowUpDto
    {
        public int FollowUpID { get; set; }
        public int PatientID { get; set; }
        public DateTime FollowUpDate { get; set; }
        public string Notes { get; set; }
    }

}
