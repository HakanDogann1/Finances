using AutoMapper;
using Finances.BusinessLayer.Abstract;
using Finances.DtoLayer.DTOs.ContactUs;
using Finances.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Finances.UI.Areas.Admin.Controllers
{
        [Area("Admin")]
        [Route("Admin/[controller]/[action]")]
        public class ContactUsController : Controller
        {
            private readonly IContactUsService _contactUsService;
            private readonly IMapper _mapper;

            public ContactUsController(IContactUsService contactUsService, IMapper mapper)
            {
                _contactUsService = contactUsService;
                _mapper = mapper;
            }

            public IActionResult Index()
            {
                var values = _contactUsService.TGetList();
                var results = _mapper.Map<List<ResultContactUsDto>>(values);
                return View(results);
            }
            public IActionResult DeleteContactUs(int id)
            {
                var value = _contactUsService.TGetByID(id);
                _contactUsService.TDelete(value);
                return RedirectToAction("Index");
            }
            [HttpGet]
            public IActionResult AddContactUs()
            {
                return View();
            }
            [HttpPost]
            public IActionResult AddContactUs(AddContactUsDto addContactUsDto)
            {
                var value = _mapper.Map<ContactUs>(addContactUsDto);
                _contactUsService.TAdd(value);
                return RedirectToAction("Index");
            }
            [HttpGet]
            public IActionResult UpdateContactUs(int id)
            {
                var value = _contactUsService.TGetByID(id);
                var result = _mapper.Map<UpdateContactUsDto>(value);
                return View(result);
            }
            [HttpPost]
            public IActionResult UpdateContactUs(UpdateContactUsDto updateContactUsDto)
            {
                var value = _mapper.Map<ContactUs>(updateContactUsDto);
                _contactUsService.TUpdate(value);
                return RedirectToAction("Index");
            }
        }
}
