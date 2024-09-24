namespace PoranMedicalProject.Models.DTO
{
    public class GuideDto
    {
        public int GuidID { get; set; }
        public string GuidName { get; set; }
        public string PhoneNo { get; set; }
        public ICollection<int> GuidPatientIDs { get; set; }
    }

}
