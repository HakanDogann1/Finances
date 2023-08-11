using AutoMapper;
using Finances.BusinessLayer.Abstract;
using Finances.DtoLayer.DTOs.Header;
using Finances.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Finances.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class HeaderController : Controller
    {
        private readonly IHeaderService _headerService;
        private readonly IMapper _mapper;

        public HeaderController(IHeaderService headerService, IMapper mapper)
        {
            _headerService = headerService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var values = _headerService.TGetList();
            var results = _mapper.Map<List<ResultHeaderDto>>(values);
            return View(results);
        }
        public IActionResult DeleteHeader(int id)
        {
            var value = _headerService.TGetByID(id);
            _headerService.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddHeader()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddHeader(AddHeaderDto addHeaderDto)
        {
            var value = _mapper.Map<Header>(addHeaderDto);
            _headerService.TAdd(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateHeader(int id)
        {
            var value = _headerService.TGetByID(id);
            var result = _mapper.Map<UpdateHeaderDto>(value);
            return View(result);
        }
        [HttpPost]
        public IActionResult UpdateHeader(UpdateHeaderDto updateHeaderDto)
        {
            var value = _mapper.Map<Header>(updateHeaderDto);
            _headerService.TUpdate(value);
            return RedirectToAction("Index");
        }
    }
}