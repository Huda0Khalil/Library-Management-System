using Library_Management_System.Application.Commands.BookCommands;
using Library_Management_System.Application.Queries.BookQueries; 

using Library_Management_System.Application.DTOs;
using Library_Management_System.Domain.Entities;
using Library_Management_System.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management_System.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMediator _mediator;


        public BooksController(IBookRepository bookRepository, IMediator mediator)
        {
            _bookRepository = bookRepository;
            _mediator = mediator;
        }

        // GET: api/books
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookRepository.GetAllAsync();
            return Ok(books);
        }

        // GET: api/books/with-category
        [HttpGet("with-category")]
        public async Task<IActionResult> GetAllBooksWithCategory()
        {
            var query = new GetAllBookQuery();
            var books = await _mediator.Send(query);
            return Ok(books);
        }

        // GET: api/books/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var query = new GetBookQuery { Id = id };
            var book = await _mediator.Send(query);
            if (book == null)
                return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] BookDto bookDto)
        {
            if (bookDto == null)
                return BadRequest();
            var command = new CreateBookCommand { BookDto = bookDto };
            
           var book = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
        }

        // PUT: api/books/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] BookDto bookDto)
        {
            if (bookDto == null || id != bookDto.Id)
                return BadRequest();
            var command = new UpdateBookCommand { Id = id, Bookdto = bookDto };
            var book = await _mediator.Send(command);
            return Ok(book);
        }

        // DELETE: api/books/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var command = new DeleteBookCommand { Id = id };
            var result = await _mediator.Send(command);
            if (result)
            {
                return Ok(new { message = "Book deleted successfully" });
            }
            else
            {
                return NotFound(new { message = "Book not found" });
            }
        }
    }
}
