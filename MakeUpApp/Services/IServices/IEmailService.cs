namespace MakeUpApp.Services.IServices
{
    public interface IEmailService
    {
        Task SendWelcomeEmailAsync(string toEmail, string firstName);
    }
}
