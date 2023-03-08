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

        public async Task<User> GetUserAsync(Guid id)
        {
            try
            {
                return await _appDbContext.users.FindAsync(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Book> UpdateBookAsync(Book book)
        {
            try
            {
                _appDbContext.Entry(book).State = EntityState.Modified;
                await _appDbContext.SaveChangesAsync();

                return book;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
