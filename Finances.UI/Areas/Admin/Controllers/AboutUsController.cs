using AutoMapper;
using Finances.BusinessLayer.Abstract;
using Finances.DtoLayer.DTOs.AboutUs;
using Finances.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Finances.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class AboutUsController : Controller
    {
        private readonly IAboutUsService _aboutUsService;
        private readonly IMapper _mapper;

        public AboutUsController(IAboutUsService aboutUsService, IMapper mapper)
        {
            _aboutUsService = aboutUsService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var values = _aboutUsService.TGetList();
            var result = _mapper.Map<List<ResultAboutUsDto>>(values);
            return View(result);
        }
        public IActionResult DeleteAboutUs(int id)
        {
            var value = _aboutUsService.TGetByID(id);
            _aboutUsService.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddAboutUs()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAboutUs(AddAboutUsDto addAboutUsDto)
        {
            var value = _mapper.Map<AboutUs>(addAboutUsDto);
            _aboutUsService.TAdd(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateAboutUs(int id)
        {
            var value = _aboutUsService.TGetByID(id);
            var result = _mapper.Map<UpdateAboutUsDto>(value);
            return View(result);
        }
        [HttpPost]
        public IActionResult UpdateAboutUs(UpdateAboutUsDto updateAboutUsDto)
        {
            var value = _mapper.Map<AboutUs>(updateAboutUsDto);
            _aboutUsService.TUpdate(value);
            return RedirectToAction("Index");
        }
    }
}
