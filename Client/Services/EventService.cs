using Newtonsoft.Json;
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

            throw null;
        }
    }
}
