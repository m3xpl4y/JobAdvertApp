using JobAdvert.Main.Data;
using JobAdvert.Main.Interfaces;
using JobAdvert.Main.Models;
using Microsoft.EntityFrameworkCore;

namespace JobAdvert.Main.Repositories
{
    public class CategoryRepository : IRepository<Category, int>
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Create(Category model)
        {
            await _context.Categories.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var model = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            _context.Categories.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(Category model)
        {
            _context.Categories.Update(model);
            await _context.SaveChangesAsync();
        }
    }
}
