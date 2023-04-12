using Microsoft.AspNetCore.Components.Authorization;
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
        private readonly AuthenticationStateProvider provider;

        public UserRepo(SignInManager<ApplicationUser> signInManager, EventDbContext context)
        {
            this.signInManager = signInManager;
            this.context = context;
        }

        public async Task<bool> RegisterUser(ApplicationUser newUser, string password, string country)
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

        public async Task<bool> SignInUser(string username, string password)
        {
            if(username != null && password != null)
            {           
                var signInResult = await signInManager.PasswordSignInAsync(username, password, false, false);

                if (signInResult.Succeeded)
                {
                    return true;
                }
            }

            return false;
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

        public async Task<bool> ChangePassword(string currentPassword, string newPassword)
        {
            var user = await signInManager.UserManager.GetUserAsync(signInManager.Context.User);

            //var newPassHash = signInManager.UserManager.PasswordHasher.HashPassword(user, newPassword);

            var result = await signInManager.UserManager.ChangePasswordAsync(user, currentPassword, newPassword);

            if (result.Succeeded)
            {
                await signInManager.SignOutAsync();
                await signInManager.PasswordSignInAsync(user.UserName, newPassword, false, false);

                return true;
            }
            return false;
        }

        public async Task<string> GetCountryAsync(string username)
        {
            var user = await signInManager.UserManager.FindByNameAsync(username);
            return user.Country;
        }
        public async Task<bool> ChangeCountry(string newCountry)
        {
            var user = await signInManager.UserManager.GetUserAsync(signInManager.Context.User);
            user.Country = newCountry;
            var result = await signInManager.UserManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }

        //public async Task<string> GetUserIdentityName()
        //{

        //var state = await provider.GetAuthenticationStateAsync();
        //var user = state.User;
        //var user = await signInManager.UserManager.GetUserAsync(signInManager.Context.User);

        //return user.Identity.Name;
        //}

        //Admins ska kunna lägga till events med datum, tid, plats, pris och kapacitet(ticketamount)
    }
}
