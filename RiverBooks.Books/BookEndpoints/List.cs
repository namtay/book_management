using FastEndpoints;
using Microsoft.AspNetCore.Builder;

namespace RiverBooks.Books;

internal class List(IBookService bookService) : EndpointWithoutRequest<ListResponse>
{
    //endpoints for books using fastendpoints library
    private readonly IBookService _bookService = bookService;

    public override void Configure()
    {
        // base.Configure();
        Get("/books");
        AllowAnonymous();
    }

    // public override async Task<ListResponse> HandleAsync(CancellationToken cancellationToken = default)
    // {
    //     // return Task.FromResult(new ListResponse
    //     // {
    //     //     Books = bookService.ListBooks()
    //     // });
    //     var books = _bookService.ListBooks();

    //     await SendAsync(new ListResponse()
    //     {
    //         Books = books
    //     });

    // }

    public override async Task HandleAsync(CancellationToken cancellationToken = default)
    {
        var books = _bookService.ListBooksAsync();

        await SendAsync(new ListResponse()
        {
            Books = await books
        }, cancellation: cancellationToken);
    }

}
