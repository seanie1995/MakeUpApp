using MakeUpApp.Models.DTOs.UserDTOS;
using Microsoft.AspNetCore.Identity;

namespace MakeUpApp.Services.IServices
{
    public interface IAuthService
    {
        Task<IdentityResult> RegisterAsync(UserRegisterDTO user);
        Task<string?> LoginAsync(UserLoginDTO user);
        Task<IdentityResult> UpdateUserAsync(UserUpdateDTO user);
    }
}
