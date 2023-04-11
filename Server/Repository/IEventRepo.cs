using TicketHiveSpaceKittens.Shared.Models;

namespace TicketHiveSpaceKittens.Server.Repository
{
    public interface IEventRepo
    {
        Task<List<EventModel>> GetEvents();
        Task<EventModel?> GetEvent(int id);
        Task<bool> CreateEvent(EventModel newEvent);
        Task<EventModel?> DeleteEvent(int id);
        Task<EventModel?> UpdateEvent(int id, EventModel updatedEvent);
        bool BookEventsToUser(List<CartEventModel> bookedEvent, string username);
    }
}
