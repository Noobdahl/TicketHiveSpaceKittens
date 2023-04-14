using TicketHiveSpaceKittens.Shared.Models;

namespace TicketHiveSpaceKittens.Client.Services
{
    public interface IEventService
    {
        Task<List<EventModel>?> GetEventsAsync();
        Task<EventModel?> GetOneEventAsync(int id);
        Task<bool> CreateEventAsync(EventModel eventModel);
        Task<bool> DeleteEventByIdAsync(int id);
        Task<bool> UpdateEventAsync(EventModel eventModel);
        Task<bool> BookEventsToUserAsync(UserModel tempUser);
        Task<List<EventModel>?> GetEventsByUsernameAsync(string username);
        Task<List<EventModel>?> GetEventsRandomAsync();
        Task<bool> RemoveTicket (CartEventModel e);
    }
}
