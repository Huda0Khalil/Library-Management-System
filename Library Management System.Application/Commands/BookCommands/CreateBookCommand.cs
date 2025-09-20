using Library_Management_System.Application.DTOs;
using Library_Management_System.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Application.Commands.BookCommands
{
    public class CreateBookCommand:IRequest<Book>
    {
        public BookDto BookDto { get; set; }
    }

}
