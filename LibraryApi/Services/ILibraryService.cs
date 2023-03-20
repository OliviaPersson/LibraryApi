using LibraryApi.Entities.Models;

namespace LibraryApi.Services
{
    public interface ILibraryService
    {
        // Author Services
        //Task<List<Author>> GetAuthorsAsync(); // GET All Authors
        //Task<Author> GetAuthorAsync(Guid id, bool includeBooks = false); // GET Single Author
        //Task<Author> AddAuthorAsync(Author author); // POST New Author
        //Task<Author> UpdateAuthorAsync(Author author); // PUT Author
        //Task<(bool, string)> DeleteAuthorAsync(Author author); // DELETE Author

        // Book Services
        Task<IEnumerable<Book>> GetBooksAsync(); // GET All Books
        Task<Book> GetBookAsync(Guid id); // Get Single Book
        Task<Book> AddBookAsync(Book book); // POST New Book
        Task<Book> UpdateBookAsync(Book book); // PUT Book
        Task<(bool, string)> DeleteBookAsync(Book book); // DELETE Book

        // User Services
        Task<IEnumerable<User>> GetUsersAsync(); // GET All Users
        Task<User> GetUserAsync(Guid id); // Get Single User
        Task<User> AddUserAsync(User user); // POST New User
        Task<User> UpdateUserAsync(User user); // PUT User
        Task<(bool, string)> DeleteUserAsync(User user); // DELETE User

        // Sign In Services
        Task<User> SignInAsync(User user); // Sign In User
    }
}
