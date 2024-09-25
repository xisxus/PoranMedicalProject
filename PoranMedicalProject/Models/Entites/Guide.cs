namespace PoranMedicalProject.Models.Entites
{
    public class Guide
    {
        public int GuidID { get; set; }
        public string GuidName { get; set; }
        public string PhoneNo { get; set; }
        public string GuidePhotoUrl { get; set; }

        // One Guid can be assigned to many Patients
        public ICollection<PatientsTravel> PatientsTravels { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Timestamp when the entry was created
        public DateTime UpdatedAt { get; set; } = DateTime.Now;  // Timestamp when the entry was last updated
    }
}
