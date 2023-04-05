using System.ComponentModel.DataAnnotations;

namespace TicketHiveSpaceKittens.Shared.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string? Country { get; set; }
        public List<EventModel> Bookings { get; set; } = new();
    }
}
