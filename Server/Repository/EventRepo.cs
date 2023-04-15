using Microsoft.EntityFrameworkCore;
using TicketHiveSpaceKittens.Server.Data;
using TicketHiveSpaceKittens.Shared.Models;

namespace TicketHiveSpaceKittens.Server.Repository
{
    public class EventRepo : IEventRepo
    {
        private readonly EventDbContext context;
        public List<EventModel> events;

        public EventRepo(EventDbContext context)
        {
            this.context = context;
        }

        public async Task<List<EventModel>> GetEvents()
        {
            return await context.Events.Include(e => e.Users).Include(e => e.Tags).Select(e => new EventModel
            {
                EventId = e.EventId,
                Name = e.Name,
                Location = e.Location,
                Description = e.Description,
                TicketPrice = e.TicketPrice,
                EventDate = e.EventDate,
                TicketsRemaining = e.TicketsRemaining,
                ImageUrl = e.ImageUrl,
                Tags = e.Tags,
                Users = e.Users
            })
                .ToListAsync();
        }

        public async Task<EventModel?> GetEvent(int id)
        {
            return await context.Events.Include(e => e.Users).Include(e => e.Tags).Where(e => e.EventId == id).Select(e => new EventModel
            {
                EventId = e.EventId,
                Name = e.Name,
                Location = e.Location,
                Description = e.Description,
                TicketPrice = e.TicketPrice,
                EventDate = e.EventDate,
                TicketsRemaining = e.TicketsRemaining,
                ImageUrl = e.ImageUrl,
                Tags = e.Tags,
                Users = e.Users
            })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> CreateEvent(EventModel newEvent)
        {
            EventModel eventToAdd = new()
            {
                Name = newEvent.Name,
                Location = newEvent.Location,
                Description = newEvent.Description,
                TicketPrice = newEvent.TicketPrice,
                EventDate = newEvent.EventDate,
                TicketsRemaining = newEvent.TicketsRemaining,
                Tags = new List<TagModel>(),
                Users = newEvent.Users,
                ImageUrl = newEvent.ImageUrl
            };

            foreach (var tag in newEvent.Tags)
            {

                TagModel functioningTag = await TagChecker(tag.TagName);
                eventToAdd.Tags.Add(functioningTag);
            }

            context.Events.Add(eventToAdd);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<EventModel?> DeleteEvent(int id)
        {
            var eventToDelete = await context.Events.FirstOrDefaultAsync(e => e.EventId == id);

            if (eventToDelete != null)
            {
                context.Events.Remove(eventToDelete);
                await context.SaveChangesAsync();
            }
            return eventToDelete;
        }

        public async Task<EventModel?> UpdateEvent(int id, EventModel updatedEvent)
        {
            var eventToUpdate = await context.Events.FirstOrDefaultAsync(e => e.EventId == id);

            if (eventToUpdate != null)
            {
                eventToUpdate.Name = updatedEvent.Name;
                eventToUpdate.Location = updatedEvent.Location;
                eventToUpdate.Description = updatedEvent.Description;
                eventToUpdate.TicketPrice = updatedEvent.TicketPrice;
                eventToUpdate.EventDate = updatedEvent.EventDate;
                eventToUpdate.TicketsRemaining = updatedEvent.TicketsRemaining;
                eventToUpdate.Tags = updatedEvent.Tags;
                eventToUpdate.Users = updatedEvent.Users;
                eventToUpdate.ImageUrl = updatedEvent.ImageUrl;

                await context.SaveChangesAsync();
            }

            return eventToUpdate;
        }

        public bool BookEventsToUser(List<EventModel> bookedEvent, string username)
        {
            UserModel? user = context.Users.Where(u => u.Username == username).Include(u => u.Bookings).ThenInclude(b => b.Tags).FirstOrDefault();

            foreach (EventModel e in bookedEvent)
            {
                EventModel? eventToUser = context.Events.Where(ev => ev.EventId == e.EventId).Include(ev => ev.Tags).Include(ev => ev.Users).FirstOrDefault();
                eventToUser.Users.Add(user);
                context.SaveChanges();
            }

            return true;
        }

        public async Task<List<EventModel>> GetEventsByUsernameAsync(string username)
        {
            List<EventModel> list = await context.Events
                .Include(e => e.Tags)
                .Include(e => e.Users)
                .Where(e => e.Users.Any(e => e.Username == username))
                .Select(e => new EventModel
                {
                    EventId = e.EventId,
                    Name = e.Name,
                    Location = e.Location,
                    Description = e.Description,
                    TicketPrice = e.TicketPrice,
                    EventDate = e.EventDate,
                    TicketsRemaining = e.TicketsRemaining,
                    ImageUrl = e.ImageUrl,
                    Tags = e.Tags,
                    Users = e.Users
                })
                .ToListAsync();

            if (list != null)
            {
                return list;
            }
            return null;
        }

        public async Task RemoveTicket(CartEventModel e)
        {
            EventModel? dbEvent = context.Events.Where(ev => ev.EventId == e.Event.EventId).FirstOrDefault();
            dbEvent.TicketsRemaining -= e.Quantity;
            await context.SaveChangesAsync();
        }
        public async Task<TagModel> TagChecker(string Tagname)
        {
            TagModel? tag = await context.Tags.Where(t => t.TagName == Tagname).Include(t => t.Events).FirstOrDefaultAsync();

            if (tag == null)
            {
                tag = new TagModel()
                {
                    TagName = Tagname,
                };
            }

            return tag;
        }

    }
}
