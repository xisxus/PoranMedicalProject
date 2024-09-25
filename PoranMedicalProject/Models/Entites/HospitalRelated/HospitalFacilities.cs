namespace PoranMedicalProject.Models.Entites.HospitalRelated
{
    public class HospitalFacilities
    {
        public int HospitalFacilitiesId { get; set; }
        public int FacilitiesId { get; set; }
        public virtual Facilities Facilities { get; set; }
        public int HospitalID { get; set; }
        public virtual Hospital Hospital { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
