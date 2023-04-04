using Microsoft.EntityFrameworkCore;
using TicketHiveSpaceKittens.Server.Models;
using TicketHiveSpaceKittens.Shared.Models;

namespace TicketHiveSpaceKittens.Server.Data
{
    public class EventDbContext : DbContext
    {
        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options)
        {

        }

        public DbSet<EventModel> Events { get; set; }
        public DbSet<EventTypesModel> EventTypes { get; set; }
        public DbSet<ExtendedUser> ExtendedUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventModel>().HasData(
                new EventModel()
                {
                    Id = 1,
                    Name = "Springbreak",
                    Location = "Backyard",
                    Description = "Fyllefest deluxe",
                    TicketPrice = 199,
                    EventDate = new DateTime(),
                    TicketsRemaining = 10,
                    ImageUrl = ""
                },
                new EventModel()
                {
                    Id = 2,
                    Name = "Springbreak2",
                    Location = "Backyard2",
                    Description = "Fyllefest deluxe2",
                    TicketPrice = 1992,
                    EventDate = new DateTime(),
                    TicketsRemaining = 102,
                    ImageUrl = ""
                }
            );

            modelBuilder.Entity<EventTypesModel>().HasData(
                new EventTypesModel()
                {
                    TypeName = "Utomhus",
                }
            );
            modelBuilder.Entity("EventModelEventTypesModel").HasData(
                new
                {
                    EventTypesTypeName = "Utomhus",
                    EventsId = 1
                }
            );
        }
    }
}