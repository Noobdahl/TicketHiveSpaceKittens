using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using TicketHiveSpaceKittens.Server.Repository;
using TicketHiveSpaceKittens.Shared.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TicketHiveSpaceKittens.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventRepo repo;

        public EventsController(IEventRepo repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<List<EventModel>> GetAllEvents()
        {
            return Ok(repo.GetEvents());
        }

        [HttpGet("{id}")]
        public ActionResult<EventModel?> GetOneEvent(int id)
        {
            return Ok(repo.GetEvent(id));
        }

        // POST api/<EventsController>
        [HttpPost]
        public async Task<ActionResult<EventModel?>> Post([FromBody] EventModel newEvent)
        {
            var isCreatedSuccessful = await repo.CreateEvent(newEvent);

            if(isCreatedSuccessful)
            {
                return Ok();
            }

            return BadRequest();
        }

        // PUT api/<EventsController>/5
        // Update
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
