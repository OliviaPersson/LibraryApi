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

        // Book Services
        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _appDbContext.books.ToListAsync();
        }

        public async Task<Book> GetBookAsync(Guid id)
        {
            try
            {
                return await _appDbContext.books.FindAsync(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            try
            {
                await _appDbContext.books.AddAsync(book);
                await _appDbContext.SaveChangesAsync();
                return await _appDbContext.books.FindAsync(book.Id);
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

        public async Task<(bool, string)> DeleteBookAsync(Book book)
        {
            try
            {
                var dbBook = await _appDbContext.books.FindAsync(book.Id);

                if (dbBook == null)
                {
                    return (false, "Book could not be found.");
                }

                _appDbContext.books.Remove(book);
                await _appDbContext.SaveChangesAsync();

                return (true, "Book got deleted.");
            }
            catch (Exception ex)
            {
                return (false, $"An error occured. Error Message: {ex.Message}");
            }
        }

        // User Services
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            try
            {
                return await _appDbContext.users.ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
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

        public async Task<User> AddUserAsync(User user)
        {
            try
            {
                await _appDbContext.users.AddAsync(user);
                await _appDbContext.SaveChangesAsync();
                return await _appDbContext.users.FindAsync(user.Id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            try
            {
                _appDbContext.Entry(user).State = EntityState.Modified;
                await _appDbContext.SaveChangesAsync();

                return user;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<(bool, string)> DeleteUserAsync(User user)
        {
            try
            {
                var dbUser = await _appDbContext.users.FindAsync(user.Id);

                if (dbUser == null)
                {
                    return (false, "User could not be found.");
                }

                _appDbContext.users.Remove(user);
                await _appDbContext.SaveChangesAsync();

                return (true, "User got deleted.");
            }
            catch (Exception ex)
            {
                return (false, $"An error occured. Error Message: {ex.Message}");
            }
        }

        //Sign In Services
        public async Task<User> SignInAsync(User user)
        {
            try
            {
                return await _appDbContext.users.FirstOrDefaultAsync(usr => usr.Email == user.Email);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
