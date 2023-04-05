using Microsoft.AspNetCore.Identity;

namespace TicketHiveSpaceKittens.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Country { get; set; }
    }
}