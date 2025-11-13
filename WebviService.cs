using System.Net;
using System.Net.Mail;
using WebviAPI.IServices;
using WebviAPI.Model;

namespace WebviAPI.Services
{
    public class WebviService : IWebviService
    {
        private readonly IConfiguration _config;

        public WebviService(IConfiguration config)
        {
            _config = config;
        }

        public void SandEmail(ContantFrom from)
        {
            var fromEmail = _config["EmailSettings:From"];
            var fromPassword = _config["EmailSettings:Password"];
            var toEmail = _config["EmailSettings:To"];

            var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = $"New Contact Message from {from.Name}",
                Body = $"Name: {from.Name}\nEmail: {from.Email}\nMessage: {from.Message}"
            };

            using var smtp = new SmtpClient("smtp.hostinger.com", 465)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(fromEmail, fromPassword)
            };

            SmtpClient smtps = new SmtpClient("smtp.hostinger.com", 465);
            smtp.Credentials = new NetworkCredential("hr@webvi.in", "},");
            smtp.EnableSsl = true;
            smtp.Timeout = 10000;

            MailMessage messages = new MailMessage();
            message.From = new MailAddress("hr@webvi.in");
            message.To.Add("hr@webvi.in");
            message.Subject = $"New message from {from.Name}";
            message.Body = $"Name: {from.Name}\nEmail: {from.Email}\nMessage: {from.Message}";

            // smtp.Send(message);

        }
    }
}

