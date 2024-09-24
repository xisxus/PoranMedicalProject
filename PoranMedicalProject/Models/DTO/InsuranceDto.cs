namespace PoranMedicalProject.Models.DTO
{
    public class InsuranceDto
    {
        public int InsuranceID { get; set; }
        public string InsuranceProvider { get; set; }
        public string PolicyNumber { get; set; }
        public int PatientID { get; set; }
    }
}
