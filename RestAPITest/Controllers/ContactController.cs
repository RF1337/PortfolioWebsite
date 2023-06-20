using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;

namespace PortfolioRestAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IConfiguration _config;

        public EmailController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost(Name = "PostContact")]
        public IActionResult PostContact(ContactData contactData)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("rasmus.ferst@gmail.com"));
            email.To.Add(MailboxAddress.Parse("rasmus.ferst@gmail.com"));
            email.Subject = "Fra portfolio!";
            email.Body = new TextPart(TextFormat.Plain) { Text = $"Mail fra: {contactData.Mail}\nSubject: {contactData.Subject}\n{contactData.Message}" };

            using var smtp = new SmtpClient();
            smtp.Connect(_config["MailHost"], 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_config["MailName"], _config["MailAppPassword"]);
            smtp.Send(email);
            smtp.Disconnect(true);

            return Ok();
        }
    }
}
