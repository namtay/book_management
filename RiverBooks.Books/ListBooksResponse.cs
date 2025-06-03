namespace RiverBooks.Books;

// public static class BookEndpoints
// {
//     public static void MapBookEndpoints(this WebApplication app)
//     {
//         app.MapGet("/books", (IBookService bookService) =>
//         {

//             return bookService.ListBooks();
//         });
//     }

// }


//fast endpoints
public class ListBooksResponse
{
    public List<BookDto> Books { get; set; }
}
