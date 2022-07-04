using JobAdvert.Main.Data;
using JobAdvert.Main.Interfaces;
using JobAdvert.Main.Models;
using Microsoft.EntityFrameworkCore;

namespace JobAdvert.Main.Repositories
{
    public class JobRepository : IRepository<Job, int>
    {
        private readonly ApplicationDbContext _context;

        public JobRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Create(Job model)
        {
            await _context.Jobs.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var model = await _context.Jobs.FirstOrDefaultAsync(x => x.Id == id);
            _context.Jobs.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Job>> GetAllAsync()
        {
            var list = await _context.Jobs
                .Include(x => x.Category)
                .ToListAsync();
            return list;
        }

        public async Task<Job> GetByIdAsync(int id)
        {
            var model = await _context.Jobs
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == id);
            return model;
        }

        public async Task Update(Job model)
        {
            _context.Update(model);
            await _context.SaveChangesAsync();
        }
    }
}
