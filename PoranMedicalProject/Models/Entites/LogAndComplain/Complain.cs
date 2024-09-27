namespace PoranMedicalProject.Models.Entites.LogAndComplain
{
    public class Complain
    {
        public int ComplainId { get; set; }
        public string ComplainType { get; set; }
        public string ComplainDescription { get; set; }
        public string ComplainStatus { get; set; }
        public DateTime ComplainDate { get; set; }
    }
}
