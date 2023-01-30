using LibraryApi.DTO;
using LibraryApi.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly DBContext DBContext;

        public BookController(DBContext DBContext)
        {
            this.DBContext = DBContext;
        }

        [HttpGet(Name = "GetBooks")]
        public async Task<ActionResult<List<BookItemDto>>> Get()
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

    }
}
