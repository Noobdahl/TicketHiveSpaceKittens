using Microsoft.AspNetCore.Identity;
using TicketHiveSpaceKittens.Server.Data;
using TicketHiveSpaceKittens.Server.Models;
using TicketHiveSpaceKittens.Shared.Models;

namespace TicketHiveSpaceKittens.Server.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly EventDbContext context;

        public UserRepo(SignInManager<ApplicationUser> signInManager, EventDbContext context)
        {
            this.signInManager = signInManager;
            this.context = context;
        }

        public async Task<bool> SignInUser(ApplicationUser newUser, string password, string country)
        {
            IdentityResult? registerResult = await signInManager.UserManager.CreateAsync(newUser, password);
            if (registerResult.Succeeded)
            {
                AddUser(newUser.UserName, country);
                var signInResult = await signInManager.PasswordSignInAsync(newUser, password, false, false);
                return signInResult.Succeeded;
            }
            return registerResult.Succeeded;
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
