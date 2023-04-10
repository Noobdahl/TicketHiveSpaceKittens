using Microsoft.AspNetCore.Mvc;
using TicketHiveSpaceKittens.Server.Repository;
using TicketHiveSpaceKittens.Shared.Models;

namespace TicketHiveSpaceKittens.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : Controller
    {
        private readonly IBookingRepo repo;
        public BookingController(IBookingRepo repo)
        {
            this.repo = repo;
        }

        [HttpPost]
        public async Task<ActionResult> AddBooking([FromBody] EventModel bookedEvent, UserModel user)
        {
            var isCreatedSuccessful = await repo.AddBookning(bookedEvent, user);

            if (isCreatedSuccessful)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
