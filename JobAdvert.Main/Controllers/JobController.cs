using JobAdvert.Main.Interfaces;
using JobAdvert.Main.Models;
using JobAdvert.Main.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JobAdvert.Main.Controllers
{
    public class JobController : Controller
    {
        private readonly IRepository<Category, int> _catRepo;
        private readonly IRepository<Job, int> _jobRepo;

        public JobController(IRepository<Category, int> catRepo,
            IRepository<Job, int> jobRepo)
        {
            _catRepo = catRepo;
            _jobRepo = jobRepo;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _jobRepo.GetAllAsync();
            var vmList = list.Select(x => new JobPostingViewModel()
            {
                Id = x.Id,
                JobTitle = x.Title,
                JobDescription = x.Description,
                Published = x.Published,
                CategoryId = x.Category.Id
            });
            return View(vmList);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var catList = await _catRepo.GetAllAsync();
            var model = new JobPostingViewModel()
            {
                CategoryList = catList,
                Published = DateTime.Now,
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,JobTitle,JobDescription, Published, CategoryId")] JobPostingViewModel model)
        {

                var category = await _catRepo.GetByIdAsync(model.CategoryId);
                var job = new Job()
                {
                    Title = model.JobTitle,
                    Description = model.JobDescription,
                    Published = model.Published,
                    Category = category,
                };
                await _jobRepo.Create(job);

                return RedirectToAction(nameof(Index));
            //If you got here, something went terrible wrong!
            //return View(model);
        }
    }
}
