using TicketHiveSpaceKittens.Server.Models;

namespace TicketHiveSpaceKittens.Server.Repository
{
    public interface IUserRepo
    {
        void AddUser(string username, string country);
        Task<bool> SignInUser(ApplicationUser newUser, string password, string country);
    }
}
