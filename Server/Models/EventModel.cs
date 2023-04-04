using TicketHiveSpaceKittens.Server.Models;

namespace TicketHiveSpaceKittens.Shared.Models
{
    public class EventModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Location { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal TicketPrice { get; set; }
        public DateTime EventDate { get; set; }
        public int TicketsRemaining { get; set; }
        public List<EventTypesModel> EventTypes { get; set; } = null!;
        public List<ApplicationUser> Users { get; set; } = new();
        public string? ImageUrl { get; set; }

        //Futures: Followers
    }
}
