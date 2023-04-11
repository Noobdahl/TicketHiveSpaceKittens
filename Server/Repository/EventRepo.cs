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
                ImageUrl = e.ImageUrl
            })
                .ToListAsync();
        }

        public async Task<EventModel?> GetEvent(int id)
        {
            return await context.Events.FirstOrDefaultAsync(e => e.EventId == id);
        }

        public async Task<bool> CreateEvent(EventModel newEvent)
        {
            try
            {
                context.Events.Add(newEvent);
                await context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
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
            UserModel? user = context.Users.Where(u => u.Username == username).FirstOrDefault();

            if (user != null)
            {
                foreach (EventModel e in bookedEvent)
                {
                    user.Bookings.Add(e);
                }
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<List<EventModel>> GetEventsByUsernameAsync(string username)
        {
            List<EventModel> listan = await context.Events
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

            if (listan != null)
            {
                return listan;
            }
            return null;
        }
    }
}
