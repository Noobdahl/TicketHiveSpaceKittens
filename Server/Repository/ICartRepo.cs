using TicketHiveSpaceKittens.Shared.Models;

namespace TicketHiveSpaceKittens.Server.Repository
{
    public interface ICartRepo
    {
        Task<List<EventModel>> AddToCart();
    }
}
