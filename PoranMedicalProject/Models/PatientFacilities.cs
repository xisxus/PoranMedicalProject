namespace PoranMedicalProject.Models
{
    public class PatientFacilities
    {
        public int PatientFacilitiesId {  get; set; }   
        public string PatientFacilitiesName { get; set; }
        public int PatientsTravelId { get; set; }
        public virtual PatientsTravel PatientsTravel { get; set; }


    }
}
