using FastEndpoints;
using Microsoft.AspNetCore.Builder;

namespace RiverBooks.Books;

internal class ListBooksEndpoint(IBookService bookService) : EndpointWithoutRequest<ListBooksResponse>
{
    //endpoints for books using fastendpoints library
    private readonly IBookService _bookService = bookService;

    public override void Configure()
    {
        // base.Configure();
        Get("/books");
        AllowAnonymous();
    }

    // public override async Task<ListBooksResponse> HandleAsync(CancellationToken cancellationToken = default)
    // {
    //     // return Task.FromResult(new ListBooksResponse
    //     // {
    //     //     Books = bookService.ListBooks()
    //     // });
    //     var books = _bookService.ListBooks();

    //     await SendAsync(new ListBooksResponse()
    //     {
    //         Books = books
    //     });

    // }

    public override async Task HandleAsync(CancellationToken cancellationToken = default)
    {
        var books = _bookService.ListBooksAsync();

        await SendAsync(new ListBooksResponse()
        {
            Books = await books
        }, cancellation: cancellationToken);
    }

}
