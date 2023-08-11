using AutoMapper;
using Finances.BusinessLayer.Abstract;
using Finances.DtoLayer.DTOs.Account;
using Finances.DtoLayer.DTOs.Account;
using Finances.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Finances.UI.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountController(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var values = _accountService.TGetList();
            var results = _mapper.Map<ResultAccountDto>(values);
            return View(results);
        }
        public IActionResult DeleteAccount(int id)
        {
            var value = _accountService.TGetByID(id);
            _accountService.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddAccount()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAccount(AddAccountDto addAccountDto)
        {
            var value = _mapper.Map<Account>(addAccountDto);
            _accountService.TAdd(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateAccount(int id)
        {
            var value = _accountService.TGetByID(id);
            var result = _mapper.Map<UpdateAccountDto>(value);
            return View(result);
        }
        [HttpPost]
        public IActionResult UpdateAccount(UpdateAccountDto updateAccountDto)
        {
            var value = _mapper.Map<Account>(updateAccountDto);
            _accountService.TUpdate(value);
            return RedirectToAction("Index");
        }
    }
}
