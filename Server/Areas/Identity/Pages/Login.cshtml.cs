using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TicketHiveSpaceKittens.Server.Models;

namespace TicketHiveSpaceKittens.Server.Areas.Identity.Pages
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<ExtendedUser> signInManager;
        public string Username { get; set; }

        public string Password { get; set; }

        public LoginModel(SignInManager<ExtendedUser> signInManager)
        {
            this.signInManager = signInManager;
        }
        public void OnGet()
        {
        }
    }
}
