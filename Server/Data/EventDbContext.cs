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
        public DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().HasData(
                new UserModel()
                {
                    UserId = 1,
                    Username = "user",
                    Country = "Sweden"
                },
                new UserModel()
                {
                    UserId = 2,
                    Username = "admin",
                    Country = "Sweden"
                }
                );
            modelBuilder.Entity<EventModel>().HasData(
                new EventModel()
                {
                    EventId = 1,
                    Name = "Coachella Valley Music and Arts Festival",
                    Location = "Indio, California",
                    Description = "A music and arts festival featuring popular and up-and-coming artists, interactive art installations, and food vendors.",
                    TicketPrice = 399,
                    EventDate = new DateTime(2023, 05, 15-17),
                    TicketsRemaining = 245,
                    ImageUrl = "image 21.jpg"
                },
                new EventModel()
                {
                    EventId = 2,
                    Name = "Sundance Film Festival",
                    Location = "Park City, Utah",
                    Description = "A film festival showcasing independent films from around the world, with screenings, panel discussions, and special events.",
                    TicketPrice = 550,
                    EventDate = new DateTime(2023, 02, 19-29),
                    TicketsRemaining = 85,
                    ImageUrl = "Sundance.jpg"
                },
                new EventModel()
                {
                    EventId = 3,
                    Name = "Comic-Con International",
                    Location = "San Diego, California",
                    Description = "A comic book and pop culture convention featuring panels, celebrity appearances, and exhibits.",
                    TicketPrice = 100,
                    EventDate = new DateTime(2023, 07, 20-23),
                    TicketsRemaining = 40,
                    ImageUrl = "ComicCon.jpg"
                },
                new EventModel()
                {
                    EventId = 4,
                    Name = "New Orleans Jazz & Heritage Festival",
                    Location = "New Orleans, Louisiana",
                    Description = "A music festival celebrating the culture and heritage of New Orleans, featuring jazz, blues, and other genres of music, as well as food and crafts vendors.",
                    TicketPrice = 70,
                    EventDate = new DateTime(2023, 04, 28),
                    TicketsRemaining = 110,
                    ImageUrl = "image 13.jpg"              
                }
            );

            modelBuilder.Entity<TagModel>().HasData(
                new TagModel()
                {
                    TagName = "Outdoor",
                },
                new TagModel()
                {
                    TagName = "Outdoor/Nature"
                },
                new TagModel()
                {
                    TagName = "Indoor",
                },
                new TagModel()
                {
                    TagName = "Outdoor/Indoor"
                }
            );
            modelBuilder.Entity("EventModelTagModel").HasData(
                new
                {
                    TagsTagName = "Outdoor/Nature",
                    EventsEventId = 1
                },
                new
                {
                    TagsTagName = "Indoor",
                    EventsEventId = 2
                },
                new
                {
                    TagsTagName = "Indoor",
                    EventsEventId = 3
                },
                new
                {
                    TagsTagName = "Outdoor/Indoor",
                    EventsEventId = 4
                }
            );
        }
    }
}