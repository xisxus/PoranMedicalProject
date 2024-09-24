namespace PoranMedicalProject.Models.DTO
{
    public class CustomerRequestDto
    {
        public int CustomerRequestID { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string Status { get; set; }
        public int PatientID { get; set; }
    }

}
