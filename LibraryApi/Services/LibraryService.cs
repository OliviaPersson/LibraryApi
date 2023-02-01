using LibraryApi.Entities.Models;
using LibraryApi.Helpers;
using LibraryApi.Services;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.services
{
    public class LibraryService : ILibraryService
    {
        private readonly AppDbContext _appDbContext;

        public LibraryService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _appDbContext.books.ToListAsync();
        }


        //public async Task<List<Book>> GetBooksAsync()
        //{
        //    try
        //    {
        //        //return await _db.books.ToListAsync();

        //        var List = await _db.books.Select(
        //            s => new Book
        //            {
        //                Id = s.Id,
        //                Author = s.Author,
        //                ImageLink = s.ImageLink,
        //                Language = s.Language,
        //                Link = s.Link,
        //                Title = s.Title,
        //                ReleaseDate = s.ReleaseDate,
        //                Format = s.Format,
        //                ISBN = s.ISBN,
        //                Description = s.Description,
        //                Pages = s.Pages,
        //                Year = s.Year,
        //            }
        //        ).ToListAsync();

        //        return List;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return null;
        //    }
        //}
    }
}
