using Microsoft.AspNetCore.Http.HttpResults;
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

        public void SandEmail(ContantFrom form)
        {
            var fromEmail = _config["EmailSettings:From"];
            var fromPassword = _config["EmailSettings:Password"];
            var toEmail = _config["EmailSettings:To"];

            var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = $"New Contact Message from {form.Name}",
                Body = $"Name: {form.Name}\nEmail: {form.Email}\nMessage: {form.Message}"
            };

            using var smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(fromEmail, fromPassword)
            };

            smtp.Send(message);
        }
    }
}

