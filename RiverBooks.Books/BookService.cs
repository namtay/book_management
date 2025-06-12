using Microsoft.AspNetCore.Identity;

namespace RiverBooks.Books;

internal class BookService : IBookService
{

    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task CreateBookAsync(BookDto newBook)
    {
        var book = new Book(newBook.Id, newBook.Title, newBook.Author, newBook.Price);
        await _bookRepository.AddAsync(book);
        await _bookRepository.SaveChangesAsync();
    }

    public async Task DeleteBookAsync(Guid id)
    {
        var bookToDelete = await _bookRepository.GetByIdAsync(id);
        if (bookToDelete is not null)
        {
            await _bookRepository.DeleteAsync(bookToDelete);
            await _bookRepository.SaveChangesAsync();
        }
    }

    public async Task<BookDto> GetBookByIdAsync(Guid id)
    {
        var book = await _bookRepository.GetByIdAsync(id);

        return new BookDto(book!.Id, book.Title, book.Author, book.Price);
    }

    public async Task<List<BookDto>> ListBooksAsync()
    {
        // return [
        //     new BookDto(Guid.NewGuid(), "1984", "George Orwell"),
        //     new BookDto(Guid.NewGuid(), "To Kill a Mockingbird", "Harper Lee"),
        //     new BookDto(Guid.NewGuid(), "Pride and Prejudice", "Jane Austen"),
        //     new BookDto(Guid.NewGuid(), "The Great Gatsby", "F. Scott Fitzgerald"),
        //     new BookDto(Guid.NewGuid(), "Brave New World", "Aldous Huxley")
        // ];

        var books = (await _bookRepository.ListAsync())
            .Select(book => new BookDto(book.Id, book.Title, book.Author, book.Price))
            .ToList();

        return books;
    }

    public async Task UpdateBookPriceAsync(Guid bookId, decimal newPrice)
    {
        var book = await _bookRepository.GetByIdAsync(bookId);
        book!.UpdatePrice(newPrice);
        await _bookRepository.SaveChangesAsync();
    }
}
