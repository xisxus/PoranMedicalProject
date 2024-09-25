namespace PoranMedicalProject.Models.Entites
{
    public class Ticket
    {
        public int TicketID { get; set; }
        public decimal TicketPrice { get; set; }
        public string TransportationType { get; set; }
        public string TransportationCompany { get; set; }
        public string DestinationCity { get; set; }
        public DateTime ArrivelTime { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Timestamp when the entry was created
        public DateTime UpdatedAt { get; set; } = DateTime.Now;  // Timestamp when the entry was last updated

        public ICollection<PatientsTravel> PatientsTravels { get; set; }

    }
}
