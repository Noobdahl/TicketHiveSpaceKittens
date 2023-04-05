using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;
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

        public List<EventModel> GetEvents()
        {
            return context.Events.Include(e => e.Users).Include(e => e.Tags).Select(e => new EventModel
            {
                EventId = e.EventId,
                Name = e.Name,
                Location = e.Location,
                Description = e.Description,
                TicketPrice = e.TicketPrice,
                EventDate = e.EventDate,
                TicketsRemaining = e.TicketsRemaining,
                ImageUrl = e.ImageUrl
            }).ToList();
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

        //public async Task<EventModel?> DeleteEvent(int id)
        //{
        //    var eventToDelete = await context.Events.FirstOrDefaultAsync(e => e.EventId == id);
        //    if(eventToDelete!= null)
        //    {
        //        context.Events.Remove(eventToDelete);
        //        await context.SaveChangesAsync();
        //    }
        //    return eventToDelete;
        //}
    }
}
