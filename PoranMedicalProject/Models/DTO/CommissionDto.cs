namespace PoranMedicalProject.Models.DTO
{
    public class CommissionDto
    {
        public int CommissionID { get; set; }
        public int AgentID { get; set; }
        public int PatientID { get; set; }
        public decimal CommissionAmount { get; set; }
        public DateTime DateEarned { get; set; }
    }
}
