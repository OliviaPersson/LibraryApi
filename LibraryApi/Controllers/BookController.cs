using LibraryApi.DTOs;
using LibraryApi.Models;
using LibraryApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDTO>>> GetBooks()
        {
            var books = await _bookService.GetBooksAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDTO>> GetBook(Guid id)
        {
            var book = await _bookService.GetBookAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(BookDTO bookDto)
        {
            await _bookService.AddBookAsync(bookDto);
            return CreatedAtAction(nameof(GetBook), new { id = bookDto.Id }, bookDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(Guid id, BookDTO bookDto)
        {
            if (id != bookDto.Id)
            {
                return BadRequest();
            }

            await _bookService.UpdateBookAsync(bookDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            await _bookService.DeleteBookAsync(id);

            return NoContent();
        }
    }
}
