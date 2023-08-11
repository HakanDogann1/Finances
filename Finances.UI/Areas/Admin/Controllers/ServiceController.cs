using AutoMapper;
using Finances.BusinessLayer.Abstract;
using Finances.DtoLayer.DTOs.Service;
using Finances.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Finances.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;
        private readonly IMapper _mapper;

        public ServiceController(IServiceService serviceService, IMapper mapper)
        {
            _serviceService = serviceService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var values = _serviceService.TGetList();
            var results = _mapper.Map<List<ResultServiceDto>>(values);
            return View(results);
        }
        public IActionResult DeleteService(int id)
        {
            var value = _serviceService.TGetByID(id);
            _serviceService.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddService()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddService(AddServiceDto addServiceDto)
        {
            var value = _mapper.Map<Service>(addServiceDto);
            _serviceService.TAdd(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateService(int id)
        {
            var value = _serviceService.TGetByID(id);
            var result = _mapper.Map<UpdateServiceDto>(value);
            return View(result);
        }
        [HttpPost]
        public IActionResult UpdateService(UpdateServiceDto updateServiceDto)
        {
            var value = _mapper.Map<Service>(updateServiceDto);
            _serviceService.TUpdate(value);
            return RedirectToAction("Index");
        }
    }
}
