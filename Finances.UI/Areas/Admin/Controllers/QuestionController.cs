using AutoMapper;
using Finances.BusinessLayer.Abstract;
using Finances.DtoLayer.DTOs.Question;
using Finances.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Finances.UI.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;
        private readonly IMapper _mapper;

        public QuestionController(IQuestionService questionService, IMapper mapper)
        {
            _questionService = questionService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var values = _questionService.TGetList();
            var results = _mapper.Map<List<ResultQuestionDto>>(values);
            return View(results);
        }
        public IActionResult DeleteQuestion(int id)
        {
            var value = _questionService.TGetByID(id);
            _questionService.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddQuestion()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddQuestion(AddQuestionDto addQuestionDto)
        {
            var value = _mapper.Map<Question>(addQuestionDto);
            _questionService.TAdd(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateQuestion(int id)
        {
            var value = _questionService.TGetByID(id);
            var result = _mapper.Map<UpdateQuestionDto>(value);
            return View(result);
        }
        [HttpPost]
        public IActionResult UpdateQuestion(UpdateQuestionDto updateQuestionDto)
        {
            var value = _mapper.Map<Question>(updateQuestionDto);
            _questionService.TUpdate(value);
            return RedirectToAction("Index");
        }
    }
}