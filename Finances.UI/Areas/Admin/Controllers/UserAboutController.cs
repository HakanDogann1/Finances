using Finances.EntityLayer.Concrete;
using Finances.UI.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Finances.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class UserAboutController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public UserAboutController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            var userAbout = new UserAboutViewModel()
            {
                Name = value.Name,
                City = value.City,
                Email = value.Email,
                Surname = value.Surname,
                UserName = value.UserName,
            };
            return View(userAbout);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserAboutViewModel userAboutViewModel)
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            value.Name = userAboutViewModel.Name;
            value.City = userAboutViewModel.City;
            value.Email = userAboutViewModel.Email;
            value.Surname = userAboutViewModel.Surname;
            value.UserName = userAboutViewModel.UserName;
            await _userManager.UpdateAsync(value);
            return RedirectToAction("Index");
        }
    }
}
