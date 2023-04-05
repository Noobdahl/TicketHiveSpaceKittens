using TicketHiveSpaceKittens.Shared.Models;

namespace TicketHiveSpaceKittens.Server.Repository
{
    public interface IEventRepo
    {
        List<EventModel> GetEvents();
        Task<EventModel?> GetEvent(int id);
        Task<bool> CreateEvent(EventModel newEvent);
        Task<EventModel?> DeleteEvent(int id);
    }
}
