using Blazored.LocalStorage;
using TicketHiveSpaceKittens.Shared.Models;

namespace TicketHiveSpaceKittens.Client.Services
{
    public class CartService : ICartService
    {
        private List<CartEventModel> cartCookies;
        private readonly ISyncLocalStorageService localStorage;

        public CartService(ISyncLocalStorageService localStorage)
        {
            this.localStorage = localStorage;

            cartCookies = localStorage.GetItem<List<CartEventModel>>("shoppingCart");

            if (cartCookies == null)
            {
                localStorage.SetItem<List<CartEventModel>>("shoppingCart", new List<CartEventModel>());
                cartCookies = localStorage.GetItem<List<CartEventModel>>("shoppingCart");
            }
        }

        public async Task AddToCartAsync(EventModel eventToAdd)
        {
            bool isEventInCart = false;

            foreach (var cartEventModel in cartCookies)
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

                cartCookies.Add(newCartItem);
                localStorage.SetItem<List<CartEventModel>>("shoppingCart", cartCookies);
                await Task.CompletedTask;
            }
        }

        public List<CartEventModel> GetCartItems()
        {
            return cartCookies;
        }

        public decimal TotalCart()
        {
            decimal total = 0;

            foreach (var cartItem in cartCookies)
            {
                total += cartItem.Quantity * cartItem.Event.TicketPrice;
            }
            return total;
        }

        public async Task RemoveFromCartAsync(CartEventModel eventToRemove)
        {
            cartCookies.Remove(eventToRemove);
            localStorage.SetItem<List<CartEventModel>>("shoppingCart", cartCookies);
            await Task.CompletedTask;
        }

        public void ClearCookie()
        {
            cartCookies.Clear();
            localStorage.SetItem<List<CartEventModel>>("shoppingCart", cartCookies);
        }
    }
}
