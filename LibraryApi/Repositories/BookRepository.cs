using LibraryApi.Data;
using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _appDbContext;

        public BookRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _appDbContext.Books.ToListAsync();
        }

        public async Task<Book> GetBookAsync(Guid id)
        {
            return await _appDbContext.Books.FindAsync(id);
        }

        public async Task AddBookAsync(Book book)
        {
            await _appDbContext.Books.AddAsync(book);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateBookAsync(Book book)
        {
            _appDbContext.Entry(book).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(Book book)
        {
            _appDbContext.Books.Remove(book);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
