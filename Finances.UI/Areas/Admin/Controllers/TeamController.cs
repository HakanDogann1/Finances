using AutoMapper;
using Finances.BusinessLayer.Abstract;
using Finances.DtoLayer.DTOs.Service;
using Finances.DtoLayer.DTOs.Team;
using Finances.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Finances.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;
        private readonly IMapper _mapper;

        public TeamController(ITeamService teamService, IMapper mapper)
        {
            _teamService = teamService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var values = _teamService.TGetList();
            var results = _mapper.Map<List<ResultTeamDto>>(values);
            return View(results);
        }
        public IActionResult DeleteService(int id)
        {
            var value = _teamService.TGetByID(id);
            _teamService.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddService()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddService(AddTeamDto addTeamDto)
        {
            var value = _mapper.Map<Team>(addTeamDto);
            _teamService.TAdd(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateService(int id)
        {
            var value = _teamService.TGetByID(id);
            var result = _mapper.Map<UpdateTeamDto>(value);
            return View(result);
        }
        [HttpPost]
        public IActionResult UpdateService(UpdateTeamDto updateTeamDto)
        {
            var value = _mapper.Map<Team>(updateTeamDto);
            _teamService.TUpdate(value);
            return RedirectToAction("Index");
        }
    }
}
