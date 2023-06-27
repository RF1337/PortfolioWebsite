using Microsoft.AspNetCore.Mvc;
using PortfolioRestAPI.DAL;
using PortfolioRestAPI.Models;
using System.Security.Cryptography.X509Certificates;

namespace PortfolioRestAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        // Dependency injecting the DALManager class
        private readonly DALManager _dALmanager;
        public ProjectController(DALManager dALmanager)
        {
            _dALmanager = dALmanager;
        }
        // Creating a GET method 
        [HttpGet(Name = "GetProjects")]
        public IEnumerable<Project> GetProjects()
        { // Returns the DALManager method named GetProject();
            return _dALmanager.GetProject();
        }
    }
}
