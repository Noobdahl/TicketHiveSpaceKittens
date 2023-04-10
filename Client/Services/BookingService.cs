using System.Net.Http.Json;
using System.Net.NetworkInformation;
using TicketHiveSpaceKittens.Shared.Models;

namespace TicketHiveSpaceKittens.Client.Services
{

    public class BookingService : IBookingService
    {
        private readonly HttpClient httpClient;
        private List<CartEventModel> cartEventsList;
        public BookingService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<bool> AddBookningAsync(EventModel bookedEvent, UserModel user)
        {
            foreach (CartEventModel cart in cartEventsList)
            {
                var response = await httpClient.PostAsJsonAsync<EventModel>("api/events", cart.Event, user.UserId);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;
            }
        }
    }
}
