using PoranMedicalProject.Models.Entites.PatientRelated;

namespace PoranMedicalProject.Models.Entites.TicketAndVisa
{
    public class VisaProcessing
    {
        public int VisaProcessingID { get; set; }

        public string ApplicationId { get; set; }

        public string VisaStatus { get; set; }
        public decimal ProcessingFee { get; set; }
        public int PatientID { get; set; }
        public Patient Patient { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now; 
        public DateTime UpdatedAt { get; set; } = DateTime.Now;  

    }
}
