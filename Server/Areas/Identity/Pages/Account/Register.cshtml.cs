using Duende.IdentityServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TicketHiveSpaceKittens.Server.Models;
using TicketHiveSpaceKittens.Server.Repository;
using TicketHiveSpaceKittens.Shared.Models;

namespace TicketHiveSpaceKittens.Server.Areas.Identity.Pages.Account
{
    [BindProperties]
    public class RegisterModel : PageModel
    {
        private readonly IUserRepo repo;
        [Required(ErrorMessage = "Username is required")]
        [MinLength(5)]
        [MaxLength(15)]
        public string? Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [MinLength(8)]
        [MaxLength(15)]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Country is required")]
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
                else
                {
                    ModelState.AddModelError("Error", "Something went wrong. Maybe the user already exists or the username/password hasn't the correct format. For Password: Text-number-symbol > 10 and Username > 5 char.!");
                }
            }
            return Page();
        }
    }
}
