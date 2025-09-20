using MediatR;

namespace Library_Management_System.Application.Commands.BookCommands
{
    public class DeleteBookCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
