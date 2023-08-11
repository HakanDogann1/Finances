using AutoMapper;
using Finances.BusinessLayer.Abstract;
using Finances.DtoLayer.DTOs.Gallery;
using Finances.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Finances.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class GalleryController : Controller
    {
        private readonly IGalleryService _galleryService;
        private readonly IMapper _mapper;

        public GalleryController(IGalleryService galleryService, IMapper mapper)
        {
            _galleryService = galleryService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var values = _galleryService.TGetList();
            var results = _mapper.Map<List<ResultGalleryDto>>(values);
            return View(results);
        }
        public IActionResult DeleteGallery(int id)
        {
            var value = _galleryService.TGetByID(id);
            _galleryService.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddGallery()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddGallery(AddGalleryDto addGalleryDto)
        {
            var value = _mapper.Map<Gallery>(addGalleryDto);
            _galleryService.TAdd(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateGallery(int id)
        {
            var value = _galleryService.TGetByID(id);
            var result = _mapper.Map<UpdateGalleryDto>(value);
            return View(result);
        }
        [HttpPost]
        public IActionResult UpdateGallery(UpdateGalleryDto updateGalleryDto)
        {
            var value = _mapper.Map<Gallery>(updateGalleryDto);
            _galleryService.TUpdate(value);
            return RedirectToAction("Index");
        }
    }
}
