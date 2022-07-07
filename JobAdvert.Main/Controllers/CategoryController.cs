using JobAdvert.Main.Models;
using JobAdvert.Main.Services;
using JobAdvert.Main.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JobAdvert.Main.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryService _service;

        public CategoryController(CategoryService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllAsync());
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Description")] CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _service.Create(model);
                return RedirectToAction(nameof(Index));
            }
            //If you got so far, something went terrible wrong!
            return View(model);
        }
        public async Task<IActionResult> Details(int id)
        {
            return View(await _service.GetModelById(id));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _service.GetModelById(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Id, Name, Description")] CategoryViewModel model)
        {
            if (model != null)
            {
                await _service.Edit(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            return View(await _service.GetModelById(id));
        }
        [HttpPost]
        public async Task<IActionResult> Delete([Bind("Id")] Category model)
        {
            await _service.Delete(model.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
