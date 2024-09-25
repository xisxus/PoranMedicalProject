using Microsoft.AspNetCore.Identity;
using System;

namespace PoranMedicalProject.Models.Entites
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
        public ICollection<Patient> Patients { get; set; }

        // One-to-one or one-to-many relation with Employee (depending on your structure)
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Timestamp when the entry was created
        public DateTime UpdatedAt { get; set; } = DateTime.Now;  // Timestamp when the entry was last updated
        public ICollection<Employee> Employees { get; set; }
        public ICollection<CommissionAgent> CommissionAgents { get; set; }
    }
}