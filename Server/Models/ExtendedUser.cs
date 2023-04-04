using TicketHiveSpaceKittens.Shared.Models;

namespace TicketHiveSpaceKittens.Server.Models
{
    public class ExtendedUser : ApplicationUser
    {
        public string? Country { get; set; }
        public List<EventModel> Events { get; set; } = new();
    }
}
