using FastEndpoints;

namespace RiverBooks.Books;

internal class Create(IBookService bookService) : Endpoint<CreateRequest, BookDto>
{
    private readonly IBookService _bookService = bookService;

    public override void Configure()
    {
        Post("/books");
        AllowAnonymous();
        Summary(s =>
        {
            s.Summary = "Adding a new Book";
            s.Description = "Add a new book to an existing list of books.";


        });
    }


    public override async Task HandleAsync(CreateRequest request, CancellationToken ct)
    {

        var newBookDto = new BookDto(request.Id ?? Guid.NewGuid(), request.Title, request.Author, request.Price);
        await _bookService.CreateBookAsync(newBookDto);

        await SendCreatedAtAsync<GetById>(new { newBookDto.Id }, newBookDto);
    }
}