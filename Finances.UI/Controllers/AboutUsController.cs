using AutoMapper;
using Finances.BusinessLayer.Abstract;
using Finances.BusinessLayer.Validations.FluentValidation;
using Finances.DtoLayer.DTOs.AboutUs;
using Finances.EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Finances.UI.Controllers
{
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
            var list = _mapper.Map<List<ResultAboutUsDto>>(values);
            return View(list);
        }
        [HttpGet]
        public IActionResult AddAboutUs()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAboutUs(AddAboutUsDto addAboutUsDto)
        {
            var values = _mapper.Map<AboutUs>(addAboutUsDto);
           if(!ModelState.IsValid)
            {
                return View();
            }
           
            _aboutUsService.TAdd(values);
            return RedirectToAction("Index");
        }
    }
}
