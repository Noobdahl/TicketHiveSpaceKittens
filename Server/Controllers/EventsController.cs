﻿using Microsoft.AspNetCore.Mvc;
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
        private readonly IUserRepo userRepo;

        public EventsController(IEventRepo repo, IUserRepo userRepo)
        {
            this.repo = repo;
            this.userRepo = userRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<EventModel>>> GetAllEvents()
        {
            return Ok(await repo.GetEvents());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventModel?>> GetOneEvent(int id)
        {
            return Ok(await repo.GetEvent(id));
        }

        [HttpGet("userevents/{username}")]
        public async Task<ActionResult<List<EventModel>>> GetEventsByUsernameAsync(string username)
        {
            var result = await repo.GetEventsByUsernameAsync(username);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<EventModel?>> AddEvent([FromBody] EventModel newEvent)
        {
            var isCreatedSuccessful = await repo.CreateEvent(newEvent);

            if (isCreatedSuccessful)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EventModel>> UpdateEvent(int id, [FromBody] EventModel updatedEvent)
        {
            if (id != updatedEvent.EventId)
            {
                return BadRequest();
            }

            var eventToUpdate = await repo.UpdateEvent(id, updatedEvent);

            if (eventToUpdate != null)
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

        [HttpPost("book")]
        public async Task<ActionResult> BookEventsToUserAsync([FromBody] UserModel tempUser)
        {

            if (repo.BookEventsToUser(tempUser.Bookings, tempUser.Username))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("remove")]
        public async Task<ActionResult> RemoveTicket([FromBody] CartEventModel e)
        {
            await repo.RemoveTicket(e);
            return Ok();
        }
    }
}
