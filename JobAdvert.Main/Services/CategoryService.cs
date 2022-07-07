using JobAdvert.Main.Interfaces;
using JobAdvert.Main.Models;
using JobAdvert.Main.ViewModels;

namespace JobAdvert.Main.Services
{
    public class CategoryService
    {
        private readonly IRepository<Category, int> _repository;

        public CategoryService(IRepository<Category, int> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            return list.Select(x => new CategoryViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
            });
        }

        public async Task Create(CategoryViewModel model)
        {
            var category = new Category()
            {
                Name = model.Name,
                Description = model.Description
            };
            await _repository.Create(category);
        }

        public async Task<CategoryViewModel> GetModelById(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            var model = new CategoryViewModel()
            {
                Id = category.Id,
                Description = category.Description,
                Name = category.Name
            };
            return model;
        }
        public async Task Edit(CategoryViewModel model)
        {
            var category = await _repository.GetByIdAsync(model.Id);

            category.Name = model.Name;
            category.Description = model.Description;
            await _repository.Update(category);
        }
        public async Task Delete(int id)
        {
            if(id != 0)
            await _repository.Delete(id);
        }
    }
}
