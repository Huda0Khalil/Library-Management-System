using Library_Management_System.Application.Commands.BookCommands;
using Library_Management_System.Domain.Entities;
using Library_Management_System.Domain.Interfaces;
using MediatR;

namespace Library_Management_System.Application.CommandsHandler.BookCommandsHandler
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Book>
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICategoryRepository _categoryRepository;
        public UpdateBookCommandHandler(IBookRepository bookRepository, ICategoryRepository categoryRepository)
        {
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task<Book> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.Id);
            if (book == null)
            {
                throw new Exception("Book not found");
            }
            book.Title = request.Bookdto.Title;
            book.Author = request.Bookdto.Author;
            book.ISBN = request.Bookdto.ISBN;
            book.PublishedYear = request.Bookdto.PublishedYear;
            book.IsAvailable = request.Bookdto.IsAvailable;
            book.Description = request.Bookdto.Description;
            book.Publisher = request.Bookdto.Publisher;
            book.Language = request.Bookdto.Language;

            var categories = new List<Category>();
            foreach (var categoryId in request.Bookdto.CategoryIds)
            {
                var category = await _categoryRepository.GetByIdAsync(categoryId);
                if (category != null)
                {
                    categories.Add(category);
                }
            }
            book.Categories = categories;
            _bookRepository.Update(book);
            await _bookRepository.SaveChangesAsync();
            return book;
        }
    }
}
