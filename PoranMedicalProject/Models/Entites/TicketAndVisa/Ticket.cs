﻿using PoranMedicalProject.Models.Entites.PatientRelated;

namespace PoranMedicalProject.Models.Entites.TicketAndVisa
{
    public class Ticket
    {
        public int TicketID { get; set; }
        public decimal TicketPrice { get; set; }
        public string TransportationType { get; set; }  //bus , train , Air
        public string TransportationCompany { get; set; } // Hanif , BR, Indigo
        public string DestinationCity { get; set; } // Kolkata
        public DateTime ArrivelTime { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Timestamp when the entry was created
        public DateTime UpdatedAt { get; set; } = DateTime.Now;  // Timestamp when the entry was last updated

        public ICollection<PatientsTravel> PatientsTravels { get; set; }

    }
}
