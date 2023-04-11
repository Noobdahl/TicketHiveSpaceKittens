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
                    EventDate = new DateTime(2023, 05, 15),
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
                    EventDate = new DateTime(2023, 02, 19),
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
                    EventDate = new DateTime(2023, 07, 20),
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
                },
                new EventModel()
                {
                    EventId = 5,
                    Name = "Kentucky Derby",
                    Location = "Louisville, Kentucky",
                    Description = "A horse racing event featuring the best thoroughbreds from around the world, as well as fashion and entertainment events.",
                    TicketPrice = 75,
                    EventDate = new DateTime(2023, 05, 06),
                    TicketsRemaining = 130,
                    ImageUrl = "KentuckyDerby.jpg"
                },
                new EventModel()
                {
                    EventId = 6,
                    Name = "Burning Man",
                    Location = "Black Rock Desert, Nevada",
                    Description = "An annual gathering of artists and free spirits, featuring large-scale art installations, live music, and a sense of community.",
                    TicketPrice = 475,
                    EventDate = new DateTime(2023, 08, 27),
                    TicketsRemaining = 150,
                    ImageUrl = "Burningman.jpg"
                },
                new EventModel()
                {
                    EventId = 7,
                    Name = "South by Southwest (SXSW)",
                    Location = "Austin, Texas",
                    Description = "A festival celebrating music, film, and interactive media, with performances, screenings, and panel discussions.",
                    TicketPrice = 1475,
                    EventDate = new DateTime(2023, 03, 10),
                    TicketsRemaining = 100,
                    ImageUrl = "SXSW.jpg"
                },
                new EventModel()
                {
                    EventId = 8,
                    Name = "Electric Daisy Carnival (EDC)",
                    Location = "Las Vegas, Nevada",
                    Description = "A music festival featuring electronic dance music (EDM) acts, carnival rides, and immersive art installations.",
                    TicketPrice = 399,
                    EventDate = new DateTime(2023, 05, 19),
                    TicketsRemaining = 20,
                    ImageUrl = "image 15.jpg"
                },
                new EventModel()
                {
                    EventId = 9,
                    Name = "Oktoberfest",
                    Location = "Munich, Germany",
                    Description = "A music festival featuring electronic dance music (EDM) acts, carnival rides, and immersive art installations.",
                    TicketPrice = 0,
                    EventDate = new DateTime(2023, 09, 16),
                    TicketsRemaining = 0,
                    ImageUrl = "OktoberFest.jpg"
                },
                new EventModel()
                {
                    EventId = 10,
                    Name = "Tour de France",
                    Location = "France",
                    Description = "A cycling race through the French countryside, featuring some of the best professional cyclists in the world.",
                    TicketPrice = 0,
                    EventDate = new DateTime(2023, 06, 24),
                    TicketsRemaining = 0,
                    ImageUrl = "TDF.jpg"
                },
                new EventModel()
                {
                    EventId = 11,
                    Name = "The Masters Tournament",
                    Location = "Augusta, Georgia",
                    Description = "A golf tournament featuring some of the best professional golfers in the world, played on the historic Augusta National Golf Club course.",
                    TicketPrice = 80,
                    EventDate = new DateTime(2023, 04, 6),
                    TicketsRemaining = 65,
                    ImageUrl = "Masters.jpg"
                },
                new EventModel()
                {
                    EventId = 12,
                    Name = "Venice Biennale",
                    Location = "Venice, Italy",
                    Description = "An art exhibition featuring works from contemporary artists from around the world, with installations throughout the city.",
                    TicketPrice = 270,
                    EventDate = new DateTime(2023, 05, 13),
                    TicketsRemaining = 150,
                    ImageUrl = "Venice.jpg"
                },
                new EventModel()
                {
                    EventId = 13,
                    Name = "Wimbledon Championships",
                    Location = "London, United Kingdom",
                    Description = "A tennis tournament featuring the world's best players, played on the historic grass courts of the All England Lawn Tennis and Croquet Club.",
                    TicketPrice = 500,
                    EventDate = new DateTime(2023, 06, 26),
                    TicketsRemaining = 250,
                    ImageUrl = "Wimbledon.jpg"
                },
                new EventModel()
                {
                    EventId = 14,
                    Name = "Ultra Music Festival",
                    Location = "Miami, Florida",
                    Description = "A music festival featuring electronic dance music (EDM) acts, as well as art installations and other performances.",
                    TicketPrice = 350,
                    EventDate = new DateTime(2023, 03, 24),
                    TicketsRemaining = 130,
                    ImageUrl = "image 4.jpg"
                },
                new EventModel()
                {
                    EventId = 15,
                    Name = "DreamHack Summer",
                    Location = "Jönköping, Sweden",
                    Description = "A digital festival featuring esports tournaments, gaming competitions, and other gaming-related activities, as well as live music performances and exhibitors.",
                    TicketPrice = 650,
                    EventDate = new DateTime(2023, 06, 17),
                    TicketsRemaining = 60,
                    ImageUrl = "image 2.jpg"
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
                },
                new
                {
                    TagsTagName = "Outdoor",
                    EventsEventId = 5
                },
                new
                {
                    TagsTagName = "Outdoor/Nature",
                    EventsEventId = 6
                },
                new
                {
                    TagsTagName = "Outdoor",
                    EventsEventId = 7
                },
                new
                {
                    TagsTagName = "Outdoor",
                    EventsEventId = 8
                },
                new
                {
                    TagsTagName = "Outdoor/Indoor",
                    EventsEventId = 9
                },
                new
                {
                    TagsTagName = "Outdoor",
                    EventsEventId = 10
                },
                new
                {
                    TagsTagName = "Outdoor",
                    EventsEventId = 11
                },
                new
                {
                    TagsTagName = "Indoor",
                    EventsEventId = 12
                },
                new
                {
                    TagsTagName = "Outdoor",
                    EventsEventId = 13
                },
                new
                {
                    TagsTagName = "Outdoor",
                    EventsEventId = 14
                },
                new
                {
                    TagsTagName = "Indoor",
                    EventsEventId = 15
                }
            );
        }
    }
}