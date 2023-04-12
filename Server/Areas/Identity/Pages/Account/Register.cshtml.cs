using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TicketHiveSpaceKittens.Server.Models;
using TicketHiveSpaceKittens.Server.Repository;
using TicketHiveSpaceKittens.Shared.Models;

namespace TicketHiveSpaceKittens.Server.Areas.Identity.Pages.Account
{
    [BindProperties]
    public class RegisterModel : PageModel
    {
        private readonly IUserRepo repo;
        public string? Username { get; set; }
        public string? Password { get; set; }
        public Countries selectedCountry { get; set; }

        public RegisterModel(IUserRepo repo)
        {
            this.repo = repo;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                ApplicationUser newUser = new() { UserName = Username };
                if (await repo.RegisterUser(newUser, Password!, selectedCountry.ToString()))
                {
                    return Redirect("~/");
                }
            }
            return Page();
        }
    }
}
