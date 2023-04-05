using TicketHiveSpaceKittens.Shared.Models;

namespace TicketHiveSpaceKittens.Server.Repository
{
    public interface IEventRepo
    {
        List<EventModel> GetEvents();
    }
}
