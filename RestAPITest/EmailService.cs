using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit.Text;
using MimeKit;
using PortfolioRestAPI.Controllers;
using static Org.BouncyCastle.Math.EC.ECCurve;
using System.Xml.Linq;
using MailKit.Net.Smtp;

namespace PortfolioRestAPI
{
    public class EmailService : ISendService
    {
        private readonly IConfiguration _config;
        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost(Name = "PostContact")]
        public void SendData(ContactData contactData)
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
            }
        }
    }
