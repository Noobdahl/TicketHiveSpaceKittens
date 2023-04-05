using TicketHiveSpaceKittens.Server.Data;
using TicketHiveSpaceKittens.Shared.Models;

namespace TicketHiveSpaceKittens.Server.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly EventDbContext context;

        public UserRepo(EventDbContext context)
        {
            this.context = context;
        }
        public void AddUser(string username, string country)
        {
            UserModel newUser = new()
            {
                Username = username,
                Country = country
            };
            context.Users.Add(newUser);
            context.SaveChanges();
        }
    }
}
