using Library_Management_System.Application.Queries.BookQueries;
using Library_Management_System.Domain.Entities;
using Library_Management_System.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Application.QueriesHandler
{
    public class GetAllBookQueryHandler : IRequestHandler<GetAllBookQuery, List<Book>>
    {
        private readonly IBookRepository _bookRepository;
        public GetAllBookQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<List<Book>> Handle(GetAllBookQuery request, CancellationToken cancellationToken)
        {
            List<Book> books = await _bookRepository.GetAllBooksCategory();
            return books;
        }
    }
}
