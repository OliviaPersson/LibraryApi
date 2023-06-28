using LibraryApi.DTOs;
using LibraryApi.Models;
using LibraryApi.Repositories;

namespace LibraryApi.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<BookDto>> GetBooksAsync()
        {
            IEnumerable<BookDto> books = (await _bookRepository.GetBooksAsync()).Select(book => MapBookToDto(book)).ToList();
            return books;
        }

        public async Task<BookDto> GetBookAsync(Guid id)
        {
            var book = await _bookRepository.GetBookAsync(id);
            return MapBookToDto(book);
        }

        public async Task AddBookAsync(BookDto bookDto)
        {
            var book = MapDtoToBook(bookDto);
            await _bookRepository.AddBookAsync(book);
        }

        public async Task UpdateBookAsync(BookDto bookDto)
        {
            var book = MapDtoToBook(bookDto);
            await _bookRepository.UpdateBookAsync(book);
        }

        public async Task DeleteBookAsync(Guid id)
        {
            var book = await _bookRepository.GetBookAsync(id);
            if (book != null)
            {
                await _bookRepository.DeleteBookAsync(book);
            }
        }

        public BookDto MapBookToDto(Book book)
        {
            return new BookDto
            {
                Id = book.Id,
                Author = book.Author,
                ImageLink = book.ImageLink,
                Language = book.Language,
                Link = book.Link,
                Pages = book.Pages,
                Title = book.Title,
                Year = book.Year,
                ReleaseDate = book.ReleaseDate,
                Format = book.Format,
                ISBN = book.ISBN,
                Description = book.Description,
                Status = book.Status
            };
        }

        public Book MapDtoToBook(BookDto bookDto)
        {
            return new Book
            {
                Id = bookDto.Id,
                Author = bookDto.Author,
                ImageLink = bookDto.ImageLink,
                Language = bookDto.Language,
                Link = bookDto.Link,
                Pages = bookDto.Pages,
                Title = bookDto.Title,
                Year = bookDto.Year,
                ReleaseDate = bookDto.ReleaseDate,
                Format = bookDto.Format,
                ISBN = bookDto.ISBN,
                Description = bookDto.Description,
                Status = bookDto.Status
            };
        }
    }
}
