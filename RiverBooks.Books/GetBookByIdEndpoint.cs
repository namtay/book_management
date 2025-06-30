using FastEndpoints;

namespace RiverBooks.Books;

public class CreateBookRequest
{
    public Guid Id? {get; set;}

    public string Title { get; set; }=string.Empty;

    public string Author { get; set; } = string.Empty;

    public string Price { get; set; }
}

internal class CreateBookEndpoint(IBookService bookService) : Endpoint<CreateBookRequest, BookDto>
{

}

internal class GetBookByIdEndpoint(IBookService bookService) : Endpoint<GetBookByIdRequest, BookDto>
{
    private readonly IBookService _bookService = bookService;

    public override void Configure()
    {
        Get("/books/{Id}");
        AllowAnonymous();
        Summary(s =>
        {
            s.Summary = "Book lookup";
            s.Description = "Retrieve information on a specific book.";            
            s.RequestParam(r => r.Id, "Id of the book to look up.");
        });
    }

    public override async Task HandleAsync(GetBookByIdRequest req, CancellationToken ct)
    {
        var book = await _bookService.GetBookByIdAsync(req.Id);

        if (book is null)
        {
            await SendNotFoundAsync();
            return;
        }
        await SendAsync(book);
        // return base.HandleAsync(req, ct); 
        
    }
}
