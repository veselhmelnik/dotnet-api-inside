using dotnet_api_inside.Data;
using dotnet_api_inside.Models;
using dotnet_api_inside.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dotnet_api_inside.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public EmailsController(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET: api/Emails
        // get number of emails with the project ready
        [HttpGet]
        public int Get()
        {
            EmailService email = new();
            return email.GetNumberOfEmails();
        }

        // GET api/<EmailsController>
        [HttpPost]
        public async Task<ActionResult<Project>> Add()
        {
            EmailService email = new();
            Project project = email.GetProjectFromEmail();
            if (project.Name != null && project.ProjectId != null)
            {
                _db.Projects.Add(project);
                await _db.SaveChangesAsync();
                return CreatedAtAction("Get", new { id = project.Id }, project);
            }
            else return Ok();
        }
    }
}
