using AutoMapper;
using Finances.BusinessLayer.Abstract;
using Finances.DtoLayer.DTOs.HowItWorks;
using Finances.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Finances.UI.Areas.Admin.Controllers
{


    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class HowItWorksController : Controller
    {
        private readonly IHowItWorksService _howItWorksService;
        private readonly IMapper _mapper;

        public HowItWorksController(IHowItWorksService howItWorksService, IMapper mapper)
        {
            _howItWorksService = howItWorksService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var values = _howItWorksService.TGetList();
            var results = _mapper.Map<List<ResultHowItWorksDto>>(values);
            return View(results);
        }
        public IActionResult DeleteHowItWorks(int id)
        {
            var value = _howItWorksService.TGetByID(id);
            _howItWorksService.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddHowItWorks()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddHowItWorks(AddHowItWorksDto addHowItWorksDto)
        {
            var value = _mapper.Map<HowItWorks>(addHowItWorksDto);
            _howItWorksService.TAdd(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateHowItWorks(int id)
        {
            var value = _howItWorksService.TGetByID(id);
            var result = _mapper.Map<UpdateHowItWorksDto>(value);
            return View(result);
        }
        [HttpPost]
        public IActionResult UpdateHowItWorks(UpdateHowItWorksDto updateHowItWorksDto)
        {
            var value = _mapper.Map<HowItWorks>(updateHowItWorksDto);
            _howItWorksService.TUpdate(value);
            return RedirectToAction("Index");
        }
    }

}
