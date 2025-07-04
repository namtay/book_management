using FastEndpoints;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace RiverBooks.Books;

internal class Delete(IBookService bookService) : Endpoint<DeleteRequest>
{
    private readonly IBookService _bookService = bookService;

    public override void Configure()
    {
        Delete("/books/{Id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteRequest request, CancellationToken ct)
    {
        await _bookService.DeleteBookAsync(request.Id);
        await SendNoContentAsync();
    }
}
