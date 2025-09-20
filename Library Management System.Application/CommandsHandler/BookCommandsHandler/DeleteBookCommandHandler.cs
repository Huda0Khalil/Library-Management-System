using Library_Management_System.Application.Commands.BookCommands;
using Library_Management_System.Domain.Interfaces;
using MediatR;

namespace Library_Management_System.Application.CommandsHandler.BookCommandsHandler
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, bool>
    {
        private readonly IBookRepository _bookRepository;
        public DeleteBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.Id);
            if (book == null)
            {
                throw new Exception("Book not found");
            }
             _bookRepository.Delete(book);
            await _bookRepository.SaveChangesAsync();
            return true;
        }
    }
}
