using AutoMapper;
using Finances.BusinessLayer.Abstract;
using Finances.DtoLayer.DTOs.Blog;
using Finances.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Finances.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;

        public BlogController(IBlogService blogService, IMapper mapper)
        {
            _blogService = blogService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var values = _blogService.TGetList();
            var results = _mapper.Map<List<ResultBlogDto>>(values);
            return View(results);
        }
        public IActionResult DeleteBlog(int id)
        {
            var value = _blogService.TGetByID(id);
            _blogService.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddBlog()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBlog(AddBlogDto addBlogDto)
        {
            var value = _mapper.Map<Blog>(addBlogDto);
            _blogService.TAdd(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateBlog(int id)
        {
            var value = _blogService.TGetByID(id);
            var result = _mapper.Map<UpdateBlogDto>(value);
            return View(result);
        }
        [HttpPost]
        public IActionResult UpdateBlog(UpdateBlogDto updateBlogDto)
        {
            var value = _mapper.Map<Blog>(updateBlogDto);
            _blogService.TUpdate(value);
            return RedirectToAction("Index");
        }
    }
}
