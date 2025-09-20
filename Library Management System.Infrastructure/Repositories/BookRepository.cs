using Library_Management_System.Domain.Entities;
using Library_Management_System.Domain.Interfaces;
using Library_Management_System.Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Net;
using static System.Reflection.Metadata.BlobBuilder;


namespace Library_Management_System.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;
        private readonly string _connectionString;


        public BookRepository(AppDbContext context) 
        {
            _context = context;
            _connectionString = context.Database.GetDbConnection().ConnectionString;
            ;
        }

        public async Task AddAsync(Book book)
        {

            await _context.Books.AddAsync(book);
        }

        public Task Delete(Book book)
        {
            _context.Books.Remove(book);
            return Task.CompletedTask;
        }
        public async Task<List<Book>> GetAllBooksCategory()
        {
            var books = new Dictionary<int, Book>(); // Change List<Book> to Dictionary<int, Book>
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("GetAllBooksWithCategories", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                int bookId = reader.GetInt32(reader.GetOrdinal("BookId"));

                if (!books.ContainsKey(bookId)) 
                {
                    books[bookId] = new Book
                    {
                        Id = bookId,
                        Title = reader.GetString(reader.GetOrdinal("Title")),
                        Author = reader.GetString(reader.GetOrdinal("Author")),
                        ISBN = reader.GetString(reader.GetOrdinal("ISBN")),
                        PublishedYear = reader.GetInt32(reader.GetOrdinal("PublishedYear")),
                        IsAvailable = reader.GetBoolean(reader.GetOrdinal("IsAvailable")),
                        Description = reader.GetString(reader.GetOrdinal("Description")),
                        Publisher = reader.GetString(reader.GetOrdinal("Publisher")),
                        Language = reader.GetString(reader.GetOrdinal("Language")),
                        Categories = new List<Category>()
                    };
                }
                books[bookId].Categories.Add(new Category
                {
                    Id = reader.GetInt32(reader.GetOrdinal("CategoryId")),
                    Name = reader.GetString(reader.GetOrdinal("CategoryName")),
                    Description = reader.GetString(reader.GetOrdinal("CategoryDescription")),
                    Books = new List<Book>() 
                });
            }
            return books.Values.ToList(); 
        }
        public async Task<List<Book>> GetAllAsync()
        {
            return await _context.Books.Include(b => b.Categories).ToListAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _context.Books.Include(b => b.Categories).FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task SaveChangesAsync()
        {
           await _context.SaveChangesAsync();
        }

        public Task Update(Book book)
        {
            _context.Books.Update(book);
            return Task.CompletedTask;
        }
    }
}
