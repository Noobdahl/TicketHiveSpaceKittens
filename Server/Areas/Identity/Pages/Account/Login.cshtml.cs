using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TicketHiveSpaceKittens.Server.Repository;

namespace TicketHiveSpaceKittens.Server.Areas.Identity.Pages.Account
{
    [BindProperties]
    public class LoginModel : PageModel
    {
        private readonly IUserRepo repo;

        public string Username { get; set; }

        public string Password { get; set; }

        public LoginModel(IUserRepo repo)
        {
            this.repo = repo;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (await repo.SignInUser(Username, Password))
            {
                return Redirect("~/home");
            }
            //Misslyckad inloggning, meddelande?
            return Page();
        }
    }
}
