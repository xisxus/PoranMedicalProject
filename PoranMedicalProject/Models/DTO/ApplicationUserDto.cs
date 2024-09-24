namespace PoranMedicalProject.Models.DTO
{
    public class ApplicationUserDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<int> Patients { get; set; }
        public ICollection<int> Employees { get; set; }
        public ICollection<int> CommissionAgents { get; set; }
    }
}
