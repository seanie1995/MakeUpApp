namespace MakeUpApp.Models.DTOs.UserDTOS
{
    public class UserUpdateDTO
    {
        public string Email { get; set; }
        public string NewPassword { get; set; }
        public string OldPassword { get; set; }
    }
}
