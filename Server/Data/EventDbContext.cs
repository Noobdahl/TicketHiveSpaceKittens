using Duende.IdentityServer.Events;
using Microsoft.EntityFrameworkCore;
using TicketHiveSpaceKittens.Shared.Models;

namespace TicketHiveSpaceKittens.Server.Data
{
    public class EventDbContext : DbContext
    {
        public EventDbContext(DbContextOptions<EventDbContext> options) :base(options)
        {

        }

        public DbSet<EventModel> Events { get; set; }

    }
}
