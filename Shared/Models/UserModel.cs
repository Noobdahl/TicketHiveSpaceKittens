namespace TicketHiveSpaceKittens.Shared.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public Countries Country { get; set; }
        public List<BookingModel> Bookings { get; set; } = new();
    }
}
