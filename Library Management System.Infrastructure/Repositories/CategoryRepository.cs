using Library_Management_System.Domain.Entities;
using Library_Management_System.Domain.Interfaces;
using Library_Management_System.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_System.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context) 
        {
            this._context = context;
        }
        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
        }

        public Task Delete(Category category)
        {
            _context.Categories.Remove(category);
            return Task.CompletedTask;
        }

        public async Task<List<Category>> GetAllAsync()
        {
           return await _context.Categories.Include(c => c.Books).ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories.Include(c => c.Books).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task SaveChangesAsync()
        {
           await _context.SaveChangesAsync();
        }

        public Task Update(Category category)
        {
            _context.Categories.Update(category);
            return Task.CompletedTask;
        }
    }
}
