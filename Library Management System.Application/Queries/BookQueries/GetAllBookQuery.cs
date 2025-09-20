using Library_Management_System.Domain.Entities;
using MediatR;

namespace Library_Management_System.Application.Queries.BookQueries
{
    public class GetAllBookQuery:IRequest<List<Book>>
    {

    }
}
