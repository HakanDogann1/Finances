using AutoMapper;
using Finances.BusinessLayer.Abstract;
using Finances.DtoLayer.DTOs.HappyCustomer;
using Finances.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Finances.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class HappyCustomerController : Controller
    {
        private readonly IHappyCustomerService _happyCustomerService;
        private readonly IMapper _mapper;

        public HappyCustomerController(IHappyCustomerService happyCustomerService, IMapper mapper)
        {
            _happyCustomerService = happyCustomerService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var values = _happyCustomerService.TGetList();
            var results = _mapper.Map<List<ResultHappyCustomerDto>>(values);
            return View(results);
        }
        public IActionResult DeleteHappyCustomer(int id)
        {
            var value = _happyCustomerService.TGetByID(id);
            _happyCustomerService.TDelete(value);
            return RedirectToAction("Index");
        }
      
    }
}
