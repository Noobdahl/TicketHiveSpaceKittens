using Newtonsoft.Json;
using System.Net.Http.Json;
using TicketHiveSpaceKittens.Shared.Models;

namespace TicketHiveSpaceKittens.Client.Services
{
    public class EventService : IEventService
    {
        private readonly HttpClient httpClient;

        public EventService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<EventModel>?> GetEventsAsync()
        {
            var response = await httpClient.GetAsync("api/events");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<EventModel>>(json);
            }

            return null;
        }

        public async Task<List<EventModel>?> GetEventsRandomAsync()
        {

            var response = await httpClient.GetAsync("api/events");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var events = JsonConvert.DeserializeObject<List<EventModel>>(json);
                var random = new Random();
                var randomEvents = events.OrderBy(e => random.Next()).Take(5).ToList();

                return randomEvents;
            }

            return null;
        }

        public async Task<EventModel?> GetOneEventAsync(int id)
        {
            var response = await httpClient.GetAsync($"api/events/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<EventModel>(json);
            }
            else
            {
                // Ska ta bort sen
                Console.WriteLine($"Fuck {id}");
                return null;
            }

        }

        public async Task<bool> CreateEventAsync(EventModel eventModel)
        {
            var response = await httpClient.PostAsJsonAsync<EventModel>("api/events", eventModel);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            var errorMessage = await response.Content.ReadAsStringAsync();
            throw new Exception($"Failed to create event. StatusCode: {response.StatusCode}, Error: {errorMessage}");
        }

        public async Task<bool> DeleteEventByIdAsync(int id)
        {
            var response = await httpClient.DeleteAsync($"api/events/{id}");

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateEventAsync(EventModel eventModel)
        {
            var response = await httpClient.PutAsJsonAsync($"api/events/{eventModel.EventId}", eventModel);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> BookEventsToUserAsync(UserModel tempUser)
        {
            var response = await httpClient.PostAsJsonAsync("api/events/book", tempUser);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task RemoveTicket(CartEventModel e)
        {
            var response = await httpClient.PostAsJsonAsync($"api/events/remove", e);
            if (response.IsSuccessStatusCode)
            {

            }

        }

        public async Task<List<EventModel>?> GetEventsByUsernameAsync(string username)
        {
            var response = await httpClient.GetAsync($"api/events/userevents/{username}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<EventModel>>(json);
            }

            return null;
        }



    }
}
