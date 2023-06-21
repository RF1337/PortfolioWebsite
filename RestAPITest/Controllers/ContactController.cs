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
        private readonly IEnumerable<ISendService> _sendServices;
        private readonly DALManager _dALManager;
        public ContactController(IEnumerable<ISendService> sendServices, DALManager dALManager)
        {
            _sendServices = sendServices;
            _dALManager = dALManager;
        }


        [HttpPost(Name = "PostContact")]
        public void SendData(ContactData contactData)
        {
            foreach(ISendService service in _sendServices)
            {
                service.SendData(contactData);
            }
        }
    }
}
