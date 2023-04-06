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

        [HttpPost]
        public async Task<ActionResult<EventModel?>> AddEvent([FromBody] EventModel newEvent)
        {
            var isCreatedSuccessful = await repo.CreateEvent(newEvent);

            if(isCreatedSuccessful)
            {
                return Ok();
            }

            return BadRequest();
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<EventModel>> UpdateEvent(int id, [FromBody] EventModel updatedEvent)
        {
            if(id != updatedEvent.EventId)
            {
                return BadRequest();
            }

            var eventToUpdate = await repo.UpdateEvent(id, updatedEvent);

            if(eventToUpdate != null)
            {
                return Ok(updatedEvent);
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EventModel>> DeleteEvent(int id)
        {
            var eventToDelete = await repo.DeleteEvent(id);

            if (eventToDelete != null)
            {
                return Ok(eventToDelete);
            }

            return BadRequest();
        }
    }
}
