using Library_Management_System.Application.Commands.BookCommands;
using Library_Management_System.Application.DTOs;
using Library_Management_System.Domain.Entities;
using Library_Management_System.Domain.Interfaces;
using MediatR;

namespace Library_Management_System.Application.CommandsHandler.BookCommandsHandler
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Book>
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICategoryRepository _categoryRepository;

        public CreateBookCommandHandler(IBookRepository bookRepository, ICategoryRepository categoryRepository)
        {
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<Book> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            List<Category> categories = new List<Category>();
            foreach (var categoryId in request.BookDto.CategoryIds)
            {
                var category = await _categoryRepository.GetByIdAsync(categoryId);
                if (category != null)
                {
                    categories.Add(category);
                }
            }
            Book book = new()
            {
                Title = request.BookDto.Title,
                Author = request.BookDto.Author,
                ISBN = request.BookDto.ISBN,
                PublishedYear = request.BookDto.PublishedYear,
                IsAvailable = request.BookDto.IsAvailable,
                Description = request.BookDto.Description,
                Publisher = request.BookDto.Publisher,
                Language = request.BookDto.Language,
                Categories = categories
            };            

             await _bookRepository.AddAsync(book);
             await _bookRepository.SaveChangesAsync();

            return book;
        }
    }
}
