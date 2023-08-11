using AutoMapper;
using Finances.BusinessLayer.Abstract;
using Finances.DtoLayer.DTOs.AboutUsService;
using Finances.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Finances.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class AboutUsServiceController : Controller
    {
        private readonly IAboutUsServiceService _aboutUsServiceService;
        private readonly IMapper _mapper;

        public AboutUsServiceController(IAboutUsServiceService aboutUsServiceService, IMapper mapper)
        {
            _aboutUsServiceService = aboutUsServiceService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var values = _aboutUsServiceService.TGetList();
            var results = _mapper.Map<List<ResultAboutUsServiceDto>>(values);
            return View(results);
        }
        public IActionResult DeleteAboutUsService(int id)
        {
            var value = _aboutUsServiceService.TGetByID(id);
            _aboutUsServiceService.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddAboutUsService()
        {
             return View();
        }
        [HttpPost]
        public IActionResult AddAboutUsService(AddAboutUsServiceDto dto)
        {
            var value = _mapper.Map<AboutUsService>(dto);
            _aboutUsServiceService.TAdd(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateAboutUsService(int id)
        {
            var value = _aboutUsServiceService.TGetByID(id);
            var result = _mapper.Map<UpdateAboutUsServiceDto>(value);
            return View(result);   
        }
        [HttpPost]
        public IActionResult UpdateAboutUsService(UpdateAboutUsServiceDto dto)
        {
            var value = _mapper.Map<AboutUsService>(dto);
            _aboutUsServiceService.TUpdate(value);
            return RedirectToAction("Index");
        }
    }
}
