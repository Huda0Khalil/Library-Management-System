using Library_Management_System.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Application.Queries.BookQueries
{
    public class GetBookQuery:IRequest<Book>
    {
        public int Id { get; set; }
    }

}
