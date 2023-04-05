using Microsoft.EntityFrameworkCore;
using TicketHiveSpaceKittens.Server.Data;
using TicketHiveSpaceKittens.Shared.Models;

namespace TicketHiveSpaceKittens.Server.Repository
{
    public class EventRepo : IEventRepo
    {
        private readonly EventDbContext context;

        public EventRepo(EventDbContext context)
        {
            this.context = context;
        }

        public List<EventModel> GetEvents()
        {
            return context.Events.Include(b => b.Users).ToList();
            //return context.Events.ToList();
        }
    }
}
