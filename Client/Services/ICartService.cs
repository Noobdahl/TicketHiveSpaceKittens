using TicketHiveSpaceKittens.Shared.Models;

namespace TicketHiveSpaceKittens.Client.Services
{
    public interface ICartService
    {
        Task AddToCartAsync(EventModel toCart);
        List<CartEventModel> GetCartItems();
        decimal TotalCartAsync();
        Task RemoveFromCartAsync(CartEventModel eventToRemove);
    }
}