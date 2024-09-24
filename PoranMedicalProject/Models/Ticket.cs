namespace PoranMedicalProject.Models
{
    public class Ticket
    {
        public int TicketID { get; set; }
        public decimal TicketPrice { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Timestamp when the entry was created
        public DateTime UpdatedAt { get; set; } = DateTime.Now;  // Timestamp when the entry was last updated

        // Tickets can be assigned to a patient
        public ICollection<Patient> Patients { get; set; }
    }
}
