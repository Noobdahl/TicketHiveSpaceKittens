using TicketHiveSpaceKittens.Shared.Models;

namespace TicketHiveSpaceKittens.Client.Services
{
    public interface IEventService
    {
        Task<List<EventModel>?> GetEventsAsync();
    }
}
