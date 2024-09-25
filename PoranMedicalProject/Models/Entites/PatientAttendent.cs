namespace PoranMedicalProject.Models.Entites
{
    public class PatientAttendent
    {
        public int PatientAttendentId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string ContactInfo { get; set; }
        public string Passport { get; set; }
        public string PhotoUrl { get; set; }
        public int PatientID { get; set; }
        public virtual Patient Patient { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now; // Timestamp when the entry was created
        public DateTime UpdatedAt { get; set; } = DateTime.Now;  // Timestamp when the entry was last updated

    }
}
