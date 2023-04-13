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
        public DateTimeOffset EventDate { get; set; } = DateTime.Now;
        public int TicketsRemaining { get; set; }
        public List<TagModel> Tags { get; set; } = new();
        public List<UserModel> Users { get; set; } = new();
        public string? ImageUrl { get; set; }

        public DateTime Date => EventDate.Date;
        public TimeSpan Time => EventDate.TimeOfDay;
        //Futures: Followers

    }
}
