using Finances.EntityLayer.Concrete;
using Finances.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph.Models;

namespace Finances.UI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel loginViewModel)
        {
            var userName = await _userManager.FindByNameAsync(loginViewModel.UserName);
            if (userName==null)
            {
                ModelState.AddModelError("", "Parola veya şifre hatalı...");
                return View();
            }
            var value = await _signInManager.PasswordSignInAsync(loginViewModel.UserName , loginViewModel.Password, true, true);
           if(value.IsLockedOut)
            {
                ModelState.AddModelError("", "5 Defa Giriş Hakkınızı Kullandınız. Tekrar Giriş İçin Bekleyin.");
                return View();
            }
            return RedirectToAction("Index","AboutUs" , new {Area="Admin"});
        }

        [HttpGet]
        public IActionResult Claims()
        {
            var userClaimList = User.Claims.Select(x => new ClaimViewModel()
            {
                Issuer = x.Issuer,
                Type = x.Type,
                Value = x.Value
            }).ToList();
            return View(userClaimList);
        }
    }
}
