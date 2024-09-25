namespace PoranMedicalProject.Models.Entites
{
    public class CommissionAgent
    {
        public int AgentID { get; set; }
        public string UserID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal CommissionRate { get; set; }
        public decimal TotalCommissionEarned { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Timestamp when the entry was created
        public DateTime UpdatedAt { get; set; } = DateTime.Now;  // Timestamp when the entry was last updated

        // One agent can have many commissions
        public ICollection<Commission> Commissions { get; set; }
    }
}
