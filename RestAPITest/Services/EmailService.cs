using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit.Text;
using MimeKit;
using PortfolioRestAPI.Controllers;
using static Org.BouncyCastle.Math.EC.ECCurve;
using System.Xml.Linq;
using MailKit.Net.Smtp;
using PortfolioRestAPI.Models;

namespace PortfolioRestAPI.Services
{
    // Creating a class named EmailService and implementing the ISendService
    public class EmailService : ISendService
    {
        // Dependency injecting the IConfuguration interface so I can use some of it's values
        private readonly IConfiguration _config;
        public EmailService(IConfiguration config)
        {
            _config = config;
        }
        // A SendData method that I need to implement
        public void SendData(ContactData contactData)
        {
            var email = new MimeMessage();
            // Adding a From to show who the message is from
            email.From.Add(MailboxAddress.Parse("rasmus.ferst@gmail.com"));
            // Adding a To to show who the message should be sent to
            email.To.Add(MailboxAddress.Parse("rasmus.ferst@gmail.com"));
            // Adding a subject which in this case is "Fra portfolio!"
            // Meaning that every time I get an email, the subject will be set to that
            email.Subject = "Fra portfolio!";
            // The content of the actual email
            email.Body = new TextPart(TextFormat.Plain) { Text = $"Mail fra: {contactData.Mail}\nSubject: {contactData.Subject}\n{contactData.Message}" };

            // Using an SmtpClient
            using var smtp = new SmtpClient();
            // Connecting to the smtp.google.com host
            smtp.Connect(_config["MailHost"], 587, SecureSocketOptions.StartTls);
            // Authenticating the mail and password
            smtp.Authenticate(_config["MailName"], _config["MailAppPassword"]);
            // Sending the actual email
            smtp.Send(email);
            // Disconnecting the client
            smtp.Disconnect(true);
        }
    }
}
