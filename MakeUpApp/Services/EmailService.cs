using MakeUpApp.Services.IServices;
using System.Net;
using System.Net.Mail;

namespace MakeUpApp.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendWelcomeEmailAsync(string toEmail, string firstName)
        {
            var smtpClient = new SmtpClient(_configuration["Email:SmtpServer"])
            {
                Port = int.Parse(_configuration["Email:SmtpPort"]),
                Credentials = new NetworkCredential(_configuration["Email:Username"], _configuration["Email:Password"]),
                EnableSsl = true
            };

            var message = new MailMessage
            {
                From = new MailAddress(_configuration["Email:from"]),
                Subject = "Welcome to MadeUpMakeUp",
                Body = $"Hi {firstName}, Thanks for singing up to MadeupMakeup! Hail Satan",
                IsBodyHtml = false
            };

            message.To.Add(toEmail);

            await smtpClient.SendMailAsync(message);
        }
    }
}
