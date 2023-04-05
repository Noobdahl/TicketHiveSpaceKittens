using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TicketHiveSpaceKittens.Server.Models;
using TicketHiveSpaceKittens.Server.Repository;

namespace TicketHiveSpaceKittens.Server.Areas.Identity.Pages.Account
{
    [BindProperties]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        public IUserRepo repo { get; }
        public string? Username { get; set; }
        public string? Password { get; set; }

        public RegisterModel(SignInManager<ApplicationUser> signInManager, IUserRepo repo)
        {
            this.signInManager = signInManager;
            this.repo = repo;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                ApplicationUser newUser = new()
                {
                    UserName = Username
                };

                var registerResult = await signInManager.UserManager.CreateAsync(newUser, Password!);
                if (registerResult.Succeeded)
                {
                    repo.AddUser(Username, "Sweden");//TODO change from sweden to input country
                    var signInResult = await signInManager.PasswordSignInAsync(newUser, Password!, false, false);
                    if (signInResult.Succeeded)
                    {
                        return Redirect("~/");
                    }
                }
            }
            return Page();
        }
    }
}
