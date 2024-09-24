namespace PoranMedicalProject.Models.DTO
{
    public class VisaDto
    {
        public int VisaID { get; set; }
        public int PatientID { get; set; }
        public string VisaStatus { get; set; }
        public decimal ProcessingFee { get; set; }
    }
}
