namespace TicketHiveSpaceKittens.Client.Services
{
    public interface IUserService
    {
        Task AddUser(string username, string country);
    }
}
