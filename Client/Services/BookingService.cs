using System.Net.Http.Json;
using TicketHiveSpaceKittens.Shared.Models;

namespace TicketHiveSpaceKittens.Client.Services
{

    public class BookingService : IBookingService
    {
        private readonly HttpClient httpClient;
        private List<CartEventModel>? cartEventsList;

        public BookingService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<bool> UpdateBookningAsync(List<CartEventModel> bookedEvents)
        {
            foreach (CartEventModel cart in bookedEvents)
            {

                //var requestBody = new
                //{
                //  Event = cart.Event,
                //  User = user,
                //};

                //var jsonRequest = JsonConvert.SerializeObject(requestBody);
                //var response = await httpClient.PostAsJsonAsync<EventModel>("api/events", new StringContent(jsonRequest, Encoding.UTF8, "application/json"));

                var response = await httpClient.PostAsJsonAsync<EventModel>("api/events", cart.Event);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
