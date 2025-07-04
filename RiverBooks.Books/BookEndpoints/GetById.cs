using FastEndpoints;

namespace RiverBooks.Books;


internal class GetById(IBookService bookService) : Endpoint<GetByIdRequest, BookDto>
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

    public override async Task HandleAsync(GetByIdRequest req, CancellationToken ct)
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
