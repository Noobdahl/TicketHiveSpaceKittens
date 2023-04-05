using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketHiveSpaceKittens.Shared.Models
{
    public class BookingModel
    {
        [Key]
        public int Id { get; set; }
        public int EventId { get; set; }
        public EventModel Event { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public UserModel User { get; set; }
        public int Tickets { get; set; }
    }
}