namespace PoranMedicalProject.Models.Input_Models
{
    public class HospitalCreateInputModel
    {
        public string HospitalName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public IFormFile Photo { get; set; }
        public IFormFile Logo { get; set; }
    }
}
