namespace PoranMedicalProject.Models.DTO
{
    public class PatientDto
    {
        public int PatientID { get; set; }
        public string Name { get; set; }
        public string ContactInfo { get; set; }
        public string Passport { get; set; }
        public ICollection<int> MedicalReports { get; set; }
        public ICollection<int> Appointments { get; set; }
        public ICollection<int> Costs { get; set; }
        public int VisaId { get; set; }
    }
}
