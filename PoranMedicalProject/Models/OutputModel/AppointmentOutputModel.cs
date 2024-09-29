namespace PoranMedicalProject.Models.OutputModel
{
    public class AppointmentOutputModel
    {
        public int AppointmentID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Description { get; set; }
        public string AppointmentFile { get; set; }
    }
}