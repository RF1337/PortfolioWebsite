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
    public class ContactController : ControllerBase
    {
        // Dependency injecting the DALManager and ISendService
        private readonly IEnumerable<ISendService> _sendServices;
        public ContactController(IEnumerable<ISendService> sendServices)
        {
            _sendServices = sendServices;
        }

        // Creating a POST method
        [HttpPost(Name = "PostContact")]
        public void SendData(ContactData contactData)
        {
            // Foreach service that the ISendService is using
            foreach(ISendService service in _sendServices)
            { // Use that specific service's SendData method
                service.SendData(contactData);
            }
        }
    }
}
