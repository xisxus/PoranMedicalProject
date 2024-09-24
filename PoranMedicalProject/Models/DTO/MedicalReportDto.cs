namespace PoranMedicalProject.Models.DTO
{
    public class MedicalReportDto
    {
        public int MedicalReportID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int PatientID { get; set; }
    }
}
