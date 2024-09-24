namespace PoranMedicalProject.Models.DTO
{
    public class CostDto
    {
        public int CostID { get; set; }
        public int PatientID { get; set; }
        public string ServiceType { get; set; }
        public decimal Amount { get; set; }
    }
}
