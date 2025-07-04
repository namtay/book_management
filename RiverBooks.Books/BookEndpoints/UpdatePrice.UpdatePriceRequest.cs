using FastEndpoints;
using FluentValidation;

namespace RiverBooks.Books;

public record UpdatePriceRequest(Guid Id, decimal NewPrice);

public class UpdateBookPriceRequestValidator: Validator <UpdatePriceRequest>
{
    public UpdateBookPriceRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEqual(Guid.Empty)
            .WithMessage("A book ID is required");

        RuleFor(x => x.NewPrice)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Book prices may not be negative");
    }
}
