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

        // POST api/<EmailsController>
        [HttpPost]
        public async Task<ActionResult<Project>> Post()
        {
            EmailService email = new(); ;
            Project project = email.GetProjectFromEmail();
            _db.Projects.Add(project);
            await _db.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = project.Id }, project);
        }

        // PUT api/<EmailsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmailsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
