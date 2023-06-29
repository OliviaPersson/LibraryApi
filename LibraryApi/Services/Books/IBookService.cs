using LibraryApi.DTOs;

namespace LibraryApi.Services.Books
{
    public interface IBookService
    {
        Task<IEnumerable<BookDTO>> GetBooksAsync();
        Task<BookDTO> GetBookAsync(Guid id);
        Task AddBookAsync(BookDTO bookDto);
        Task UpdateBookAsync(BookDTO bookDto);
        Task DeleteBookAsync(Guid id);
    }
}
