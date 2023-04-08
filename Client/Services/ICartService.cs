using TicketHiveSpaceKittens.Shared.Models;

namespace TicketHiveSpaceKittens.Client.Services
{
    public interface ICartService
    {
        Task AddToCartAsync(EventModel toCart);
        List<EventModel> GetCartItemsAsync();
        decimal TotalCartAsync();
        Task RemoveFromCartAsync(EventModel eventToRemove);
    }
}
