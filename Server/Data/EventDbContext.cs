using Microsoft.EntityFrameworkCore;
using TicketHiveSpaceKittens.Shared.Models;

namespace TicketHiveSpaceKittens.Server.Data
{
    public class EventDbContext : DbContext
    {
        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options)
        {

        }

        public DbSet<EventModel> Events { get; set; }
        public DbSet<TagModel> Tags { get; set; }
        public DbSet<BookingModel> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventModel>().HasData(
                new EventModel()
                {
                    EventId = 1,
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
                    EventId = 2,
                    Name = "Springbreak2",
                    Location = "Backyard2",
                    Description = "Fyllefest deluxe2",
                    TicketPrice = 1992,
                    EventDate = new DateTime(),
                    TicketsRemaining = 102,
                    ImageUrl = ""
                }
            );

            modelBuilder.Entity<TagModel>().HasData(
                new TagModel()
                {
                    TagName = "Utomhus",
                }
            );
            modelBuilder.Entity("EventModelTagModel").HasData(
                new
                {
                    TagsTagName = "Utomhus",
                    EventsEventId = 1
                }
            );
        }
    }
}