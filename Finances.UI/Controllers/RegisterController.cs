using Finances.EntityLayer.Concrete;
using Finances.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Finances.UI.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(RegisterViewModel registerViewModel)
        {
            var appUser = new AppUser()
            {
                Name = registerViewModel.Name,
                Surname = registerViewModel.Surname,
                UserName = registerViewModel.UserName,
                Image=registerViewModel.Image,
                City = registerViewModel.City,
                Email = registerViewModel.EMail
            };
            var values = await _userManager.CreateAsync(appUser,registerViewModel.Password);
            if (!values.Succeeded)
            {
                foreach (var item in values.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();

            }
            return RedirectToAction("Index","Login");
        }
    }
}
