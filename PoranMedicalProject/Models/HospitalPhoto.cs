namespace PoranMedicalProject.Models
{
    public class HospitalPhoto
    {
        public int HospitalPhotoId { get; set; }
        public string Caption { get; set; }
        public string HospitalPhotoUrl { get; set; }
        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now; // Timestamp when the entry was created
        public DateTime UpdatedAt { get; set; } = DateTime.Now;  // Timestamp when the entry was last updated
    }
}
