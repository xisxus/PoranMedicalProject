namespace PoranMedicalProject.Models.DTO
{
 
    public class UserDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

   
    public class LoginDTO
    {
        public string EmailOrPhone { get; set; }
        public string Password { get; set; }
    }

    public class UserSession
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public UserSession(string id, string name, string email, string role)
        {
            Id = id;
            Name = name;
            Email = email;
            Role = role;
        }
    }

}
