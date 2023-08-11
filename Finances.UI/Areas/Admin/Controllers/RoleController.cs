using Finances.EntityLayer.Concrete;
using Finances.UI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Finances.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var values =  _roleManager.Roles.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(AppRole appRole)
        {
          
            await _roleManager.CreateAsync(appRole);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteRole(int id)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            await _roleManager.DeleteAsync(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            return View(value);
        }
        [HttpPost]
        public async  Task<IActionResult> UpdateRole(UpdateRoleViewModel updateRoleViewModel)
        {
            var appRole = new AppRole()
            {
                Id = updateRoleViewModel.RoleID,
                Name = updateRoleViewModel.RoleName
            };
            await _roleManager.UpdateAsync(appRole);
            return RedirectToAction("Index");
        }

    }
}
