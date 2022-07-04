using JobAdvert.Main.Interfaces;
using JobAdvert.Main.Models;
using JobAdvert.Main.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JobAdvert.Main.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IRepository<Category, int> _categoryRepo;

        public CategoryController(IRepository<Category, int> categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _categoryRepo.GetAllAsync();
            var vmList = list.Select(x => new CategoryViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
            });
            return View(vmList);
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
                var category = new Category()
                {
                    Name = model.Name,
                    Description = model.Description
                };
                await _categoryRepo.Create(category);

                return RedirectToAction(nameof(Index));
            }
            //If you got so far, something went terrible wrong!
            return View(model);
        }
    }
}
