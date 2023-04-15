namespace TicketHiveSpaceKittens.Client.Services
{
    /// <summary>
    /// Interface for UserService
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Posts username and country to api.
        /// </summary>
        Task AddUser(string username, string country);

        /// <summary>
        /// Gets users country from api by sending username.
        /// </summary>
        /// <returns>Users country as string</returns>
        Task<string> GetUserCountryAsync(string username);
    }
}
