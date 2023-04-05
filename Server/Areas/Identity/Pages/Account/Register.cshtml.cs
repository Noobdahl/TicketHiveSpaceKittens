using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TicketHiveSpaceKittens.Server.Models;

namespace TicketHiveSpaceKittens.Server.Areas.Identity.Pages.Account
{
    [BindProperties]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        public string? Username { get; set; }
        public string? Password { get; set; }

        public RegisterModel(SignInManager<ApplicationUser> signInManager)
        {
            this.signInManager = signInManager;
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
                    //service.AddUser(Username, "Sweden"); //TODO change country to input
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
