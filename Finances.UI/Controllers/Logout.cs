using Finances.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Finances.UI.Controllers
{
    public class Logout : Controller
    {
        private readonly SignInManager<AppUser> _userManager;

        public Logout(SignInManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            await _userManager.SignOutAsync();
            return RedirectToAction("Index","Login");
        }
    }
}
