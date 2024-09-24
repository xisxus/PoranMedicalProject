namespace PoranMedicalProject.Models.DTO
{
    public class EmployeeDto
    {
        public int EmployeeID { get; set; }
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
    }
}
