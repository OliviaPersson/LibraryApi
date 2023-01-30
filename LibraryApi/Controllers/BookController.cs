using LibraryApi.DTO;
using LibraryApi.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class BooksController : ControllerBase
    {
        private readonly DBContext DBContext;

        public BooksController(DBContext DBContext)
        {
            this.DBContext = DBContext;
        }

        [HttpGet("books")]
        public async Task<ActionResult<List<BookItemDto>>> GetAll()
        {
            var List = await DBContext.mytable.Select(
                s => new BookItemDto
                {
                    Id = s.Id,
                    Author = s.Author,
                    ImageLink = s.ImageLink,
                    Language = s.Language,
                    Link = s.Link,
                    Title = s.Title,
                    ReleaseDate = s.ReleaseDate,
                    Format = s.Format,
                    ISBN = s.ISBN,
                    Description = s.Description,
                    Pages = s.Pages,
                    Year = s.Year,
                }
            ).ToListAsync();

            if (List.Count < 0)
            {
                return NotFound();
            }
            else
            {
                return List;
            }
        }

        [HttpGet("book/{Id}")]
        public async Task<ActionResult<BookItemDto>> GetBookById(string Id)
        {
            BookItemDto User = await DBContext.mytable.Select(s => new BookItemDto
            {
                Id = s.Id,
                Author = s.Author,
                ImageLink = s.ImageLink,
                Language = s.Language,
                Link = s.Link,
                Title = s.Title,
                ReleaseDate = s.ReleaseDate,
                Format = s.Format,
                ISBN = s.ISBN,
                Description = s.Description,
                Pages = s.Pages,
                Year = s.Year
            }).FirstOrDefaultAsync(s => string.Equals(s.Id, Id));
            if (User == null)
            {
                return NotFound();
            }
            else
            {
                return User;
            }
        }

    }
}
