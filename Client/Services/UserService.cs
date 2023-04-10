using System.Net.Http.Json;

namespace TicketHiveSpaceKittens.Client.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient httpClient;

        public UserService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task AddUser(string username, string country)
        {
            await httpClient.PostAsJsonAsync("api/users", username);
        }
    }
}
z