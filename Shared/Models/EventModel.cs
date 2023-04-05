using System.ComponentModel.DataAnnotations;

namespace TicketHiveSpaceKittens.Shared.Models
{
    public class EventModel
    {
        [Key]
        public int EventId { get; set; }
        public string Name { get; set; } = null!;
        public string? Location { get; set; }
        public string? Description { get; set; }
        public decimal TicketPrice { get; set; }
        public DateTime EventDate { get; set; }
        public int TicketsRemaining { get; set; }
        public List<TagModel> Tags { get; set; } = null!;
        public List<UserModel> Users { get; set; } = new();
        public string? ImageUrl { get; set; }

        //Futures: Followers
    }
}
