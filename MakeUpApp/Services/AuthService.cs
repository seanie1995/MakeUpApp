using MakeUpApp.Models;
using MakeUpApp.Models.DTOs.UserDTOS;
using MakeUpApp.Services.IServices;
using Microsoft.AspNetCore.Identity;

namespace MakeUpApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly JwtService _jwtService;
        private readonly IEmailService _emailService;

        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, JwtService jwtService, IEmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;
            _emailService = emailService;
        }
      
        public async Task<IdentityResult> RegisterAsync(UserRegisterDTO user)
        {
            var newUser = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,         
                UserName = user.Email              
            };

            var result =  await _userManager.CreateAsync(newUser, user.Password);

            if (result.Succeeded) 
            {
                await _emailService.SendWelcomeEmailAsync(user.Email, user.FirstName);
            }

            return result;
            
        }

        public async Task<string?> LoginAsync(UserLoginDTO user)
        {
            var existingUser = await _userManager.FindByEmailAsync(user.Email);

            if (existingUser == null) return null;

            var result = await _signInManager.PasswordSignInAsync(existingUser.UserName, user.Password, false, false);

            if (!result.Succeeded) return null;

            return _jwtService.GenerateToken(existingUser);
        }

        public async Task<IdentityResult> UpdateUserAsync(UserUpdateDTO user)
        {
            var existingUser = await _userManager.FindByEmailAsync(user.Email);

            if (existingUser == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found" });
            }
            
           
            if (!string.IsNullOrWhiteSpace(user.NewPassword) && !string.IsNullOrWhiteSpace(user.OldPassword))
            {
                var changePasswordResult = await _userManager.ChangePasswordAsync(existingUser, user.OldPassword, user.NewPassword);

                if (!changePasswordResult.Succeeded)
                {
                    return changePasswordResult;
                }
            }

            return await _userManager.UpdateAsync(existingUser);
        }
    }
}
