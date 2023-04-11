using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TicketHiveSpaceKittens.Server.Repository;
using TicketHiveSpaceKittens.Shared.Models;

namespace TicketHiveSpaceKittens.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : Controller
    {
        private readonly IBookingRepo repo;
        private UserManager<IdentityUser>? userManager { get; set; }
        public BookingController(IBookingRepo repo)
        {
            this.repo = repo;
        }

        [HttpPost]
        public async Task<ActionResult> UpdateBookningAsync([FromBody] EventModel bookedEvent, UserModel user)
        {
            var responseUserId = (await userManager.GetUserAsync(HttpContext.User)).Id;
            int userId = int.Parse(responseUserId);

            var isCreatedSuccessful = await repo.UpdateEventToUser(bookedEvent.EventId, userId);

            if (isCreatedSuccessful)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
