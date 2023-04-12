using TicketHiveSpaceKittens.Shared.Models;

namespace TicketHiveSpaceKittens.Client.Services
{
    public interface ICartService
    {
        Task AddToCartAsync(EventModel toCart);
        List<CartEventModel> GetCartItems();
        decimal TotalCart();
        Task RemoveFromCartAsync(CartEventModel eventToRemove);
        void ClearCookie();
    }
}