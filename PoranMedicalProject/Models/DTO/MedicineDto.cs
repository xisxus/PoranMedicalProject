namespace PoranMedicalProject.Models.DTO
{
    public class MedicineDto
    {
        public int MedicineID { get; set; }
        public string MedicineName { get; set; }
        public decimal Price { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
