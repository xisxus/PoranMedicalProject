namespace PoranMedicalProject.Models.Entites.CustomerSupport
{
    public class CustomerCallRequest
    {
        public int CustomerCallRequestID { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }

        public string? Status { get; set; }
        public string? StatusMessage { get; set; }



        // Each request may belong to one patient

        public DateTime CreatedAt { get; set; } = DateTime.Now; // Timestamp when the entry was created
        public DateTime UpdatedAt { get; set; } = DateTime.Now;  // Timestamp when the entry was last updated
    }
}
