namespace TicketHiveSpaceKittens.Shared.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Email { get; set; }
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public Countries Country { get; set; }
        public List<EventViewModel> BookedEvents { get; set; } = new();
    }
}
