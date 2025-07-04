using FastEndpoints;

namespace RiverBooks.Books;

internal class UpdatePrice(IBookService bookService) : Endpoint<UpdatePriceRequest, BookDto>
{
    private readonly IBookService _bookService = bookService;

     public override void Configure()
    {
        Post("/books/{Id}/priceHistory");
        AllowAnonymous();
        Summary(s =>
        {
            s.Summary = "Update Book";
            s.Description = "Update the price of a new book.";

        });
    }


    public override async Task HandleAsync(UpdatePriceRequest request, CancellationToken ct)
    {   
        await _bookService.UpdateBookPriceAsync(request.Id, request.NewPrice);
        var updatedBook = await _bookService.GetBookByIdAsync(request.Id);
        await SendAsync(updatedBook);
    }
}
