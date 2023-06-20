using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace PortfolioRestAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly DALManager _dALmanager;

        public ProjectController(DALManager dALmanager)
        {
            _dALmanager = dALmanager;
        }

        [HttpGet(Name = "GetProjects")]
        public IEnumerable<Project> GetProjects()
        {
            return _dALmanager.GetProject();
        }
    }
}
