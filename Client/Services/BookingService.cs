using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Net.NetworkInformation;
using System.Security.Claims;
using TicketHiveSpaceKittens.Client.Pages;
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

            public async Task<bool> UpdateBookningAsync(EventModel bookedEvents)
        {
            foreach (CartEventModel cart in cartEventsList)
            {

                //var requestBody = new
                //{
                //  Event = cart.Event,
                //  User = user,
                //};

                //var jsonRequest = JsonConvert.SerializeObject(requestBody);
                //var response = await httpClient.PostAsJsonAsync<EventModel>("api/events", new StringContent(jsonRequest, Encoding.UTF8, "application/json"));

                var response = await httpClient.PostAsJsonAsync<EventModel>("api/events",cart.Event);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
