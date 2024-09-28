using PoranMedicalProject.Models.Entites.TreatmentAndSurgery;

namespace PoranMedicalProject.Models.Entites.TicketAndVisa
{
    public class VisaApply
    {
        public int VisaApplyID { get; set; }
        public int VisaApplicationFormID { get; set; }
        public VisaApplicationForm VisaApplicationForm { get; set; }
        public int TreatmentPlanID { get; set; }
        public TreatmentPlan TreatmentPlan { get; set; }
       public string VisaApplyFor { get; set; }//patient or attendant
        

    }
}
