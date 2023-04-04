namespace TicketHiveSpaceKittens.Shared.Models
{
    public class BookingModel
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public EventViewModel Event { get; set; }
        public int UserId { get; set; }
        public int Tickets { get; set; }
    }
}