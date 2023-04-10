using Blazored.LocalStorage;
using TicketHiveSpaceKittens.Shared.Models;

namespace TicketHiveSpaceKittens.Client.Services
{
    public class CartService : ICartService
    {
        private List<CartEventModel> cartStorage;
        private readonly ISyncLocalStorageService localStorage;

        public CartService(ISyncLocalStorageService localStorage)
        {
            this.localStorage = localStorage;

            cartStorage = localStorage.GetItem<List<CartEventModel>>("shoppingCart");

            if (cartStorage == null)
            {
                localStorage.SetItem<List<CartEventModel>>("shoppingCart", new List<CartEventModel>());
                cartStorage = localStorage.GetItem<List<CartEventModel>>("shoppingCart");
            }
        }

        public async Task AddToCartAsync(EventModel eventToAdd)
        {
            bool isEventInCart = false;
            foreach (var cartEventModel in cartStorage)
            {
                if (cartEventModel.Event.EventId == eventToAdd.EventId)
                {
                    cartEventModel.Quantity++;
                    isEventInCart = true;
                    break;
                }
            }

            if (!isEventInCart)
            {
                CartEventModel newCartItem = new()
                {
                    Event = eventToAdd,
                    Quantity = 1
                };

                cartStorage.Add(newCartItem);
                localStorage.SetItem<List<CartEventModel>>("shoppingCart", cartStorage);
                await Task.CompletedTask;
            }
        }

        public List<CartEventModel> GetCartItemsAsync()
        {
            return cartStorage;
        }

        public decimal TotalCartAsync()
        {
            decimal total = 0;

            foreach (var cartItem in cartStorage)
            {
                for (int i = 0; i < cartItem.Quantity; i++)
                {
                    total += cartItem.Event.TicketPrice;
                }
            }
            return total;
        }

        public async Task RemoveFromCartAsync(CartEventModel eventToRemove)
        {
            cartStorage.Remove(eventToRemove);
            localStorage.SetItem<List<CartEventModel>>("shoppingCart", cartStorage);
            await Task.CompletedTask;
        }
    }
}
