using Library_Management_System.Domain.Entities;

namespace Library_Management_System.Domain.Interfaces
{
    public interface IBookRepository
    {
        Task<Book> GetByIdAsync(int id);
        Task AddAsync(Book book);
        Task Update(Book book);
        Task Delete(Book book);
        Task<List<Book>> GetAllAsync();
        Task<List<Book>> GetAllBooksCategory();
        Task SaveChangesAsync();
    }
}
