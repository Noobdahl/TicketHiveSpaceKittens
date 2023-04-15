using TicketHiveSpaceKittens.Shared.Models;

namespace TicketHiveSpaceKittens.Client.Services
{
    public interface ICartService
    {
        /// <summary>
        /// Adds specified EventModel to "shoppingCart"-cookie. If event is already in cart, increments the quantity instead.
        /// </summary>
        Task AddToCartAsync(EventModel toCart);

        /// <summary>
        /// Gets content of "shoppingCart"-cookie.
        /// </summary>
        /// <returns>"shoppingCart"-cookie as a List of CartEventModel</returns>
        List<CartEventModel> GetCartItems();

        /// <summary>
        /// Gets total price from all events in "shoppingCart"-cookie
        /// </summary>
        /// <returns>Total price as decimal</returns>
        decimal TotalCart();

        /// <summary>
        /// Removes specified CartEventModel from "shoppingCart"-cookie.
        /// </summary>
        /// <param name="eventToRemove"></param>
        Task RemoveFromCartAsync(CartEventModel eventToRemove);

        /// <summary>
        /// Clears cookie by setting "shoppingCart"-cookie to a cleared List of CartEventModel.
        /// </summary>
        void ClearCookie();
    }
}