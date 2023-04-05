using TicketHiveSpaceKittens.Shared.Models;

namespace TicketHiveSpaceKittens.Client.Services
{
    public interface IEventService
    {
        Task<List<EventModel>?> GetEventsAsync();
        Task<EventModel?> GetOneEventAsync(int id);
        Task<bool> CreateEventAsync(EventModel eventModel);
        Task<bool> DeleteEventByIdAsync(int id);
    }
}
