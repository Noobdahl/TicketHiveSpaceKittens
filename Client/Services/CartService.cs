using Newtonsoft.Json;
using TicketHiveSpaceKittens.Shared.Models;

namespace TicketHiveSpaceKittens.Client.Services
{
    public class CartService : ICartService
    {
        private List<EventModel> cartItems;
        public CartService()
        {
            cartItems = new List<EventModel>();
        }

        public async Task AddToCartAsync(EventModel toCart)
        {
            cartItems.Add(toCart);
            await Task.CompletedTask;
        }

        public List<EventModel> GetCartItemsAsync()
        {
            return cartItems;
        }

        public decimal TotalCartAsync()
        {
            decimal total = 0;

            foreach (var cartItems in cartItems)
            {
                total += cartItems.TicketPrice;
            }

            return total;
        }

        public async Task RemoveFromCartAsync(EventModel eventToRemove)
        {
            cartItems.Remove(eventToRemove);
            await Task.CompletedTask;
        }
    }
}
