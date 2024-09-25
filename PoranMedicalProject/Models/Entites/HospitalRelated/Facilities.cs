namespace PoranMedicalProject.Models.Entites.HospitalRelated
{
    public class Facilities
    {
        public int FacilitiesId { get; set; }
        public string FacilitiesDescription { get; set; }

        public ICollection<HospitalFacilities> HospitalFacilities { get; set; }
    }
}
