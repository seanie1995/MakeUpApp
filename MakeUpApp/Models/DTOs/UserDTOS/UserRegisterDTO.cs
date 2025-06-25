namespace MakeUpApp.Models.DTOs.UserDTOS
{
    public class UserRegisterDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public required string? Email { get; set; }
        public required string? Password { get; set; }
       
    }
}
