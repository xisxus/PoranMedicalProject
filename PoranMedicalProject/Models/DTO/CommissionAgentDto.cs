namespace PoranMedicalProject.Models.DTO
{
    public class CommissionAgentDto
    {
        public int AgentID { get; set; }
        public string UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal CommissionRate { get; set; }
        public decimal TotalCommissionEarned { get; set; }
        public ICollection<int> CommissionIDs { get; set; } // Reference to Commission
    }
}
