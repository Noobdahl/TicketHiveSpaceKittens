using Newtonsoft.Json;
using TicketHiveSpaceKittens.Shared.Models;

namespace TicketHiveSpaceKittens.Client.Services
{
    public class CartService
    {
        private List<EventModel> cartItems;
        public CartService()
        {
            cartItems = new List<EventModel>();
        }

        public async Task AddEventToCartAsync(EventModel eventToAdd)
        {
            cartItems.Add(eventToAdd);
            await Task.CompletedTask;
        }

        public List<EventModel> GetCartItems()
        {
            return cartItems;
        }
    }
}
