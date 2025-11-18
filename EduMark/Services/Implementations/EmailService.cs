using System.Net;
using System.Net.Mail;
using EduMark.Services.Interfaces;

namespace EduMark.Services.Implementations
{
    public class EmailService : IEmailService
    {
        private readonly string smtpServer = "smtp.gmail.com";
        private readonly int smtpPort = 587;

        private readonly string senderEmail = "noreply.sender.verify@gmail.com";
        private readonly string senderPassword = "tvpcdtzozxilodsg"; // remove spaces

        public async Task SendOtpAsync(string toEmail, string otp)
        {
            var message = new MailMessage();
            message.From = new MailAddress(senderEmail);
            message.To.Add(toEmail);
            message.Subject = "EduMark Verification Code";
            message.Body = $"Your verification code is: {otp}";

            using var smtp = new SmtpClient(smtpServer, smtpPort)
            {
                Credentials = new NetworkCredential(senderEmail, senderPassword),
                EnableSsl = true
            };

            await smtp.SendMailAsync(message);
        }
    }
}
