using Library_Management_System.Domain.Entities;

namespace Library_Management_System.Domain.Interfaces
{
   public interface ICategoryRepository
    {
        Task AddAsync(Category category);
        Task Update(Category category);
        Task Delete(Category category);
        Task<List<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);
        Task SaveChangesAsync();
    }
}
