using Duende.IdentityServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TicketHiveSpaceKittens.Server.Repository;

namespace TicketHiveSpaceKittens.Server.Areas.Identity.Pages.Account
{
    [BindProperties]
    public class LoginModel : PageModel
    {
        private readonly IUserRepo repo;
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
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
            if (ModelState.IsValid)
            {
                if (await repo.SignInUser(Username, Password))
                {
                    return Redirect("~/home");
                }
            
            else
            {
                ModelState.AddModelError("", "Invalid login .");
            }
            }
                else
                {
                    ModelState.AddModelError("Username", "Username Is Wrong");
                    ModelState.AddModelError("Password", "Password Is Wrong");
                }
                    return Page();
        }
    }
}
