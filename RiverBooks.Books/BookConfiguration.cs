using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RiverBooks.Books;

internal class BookConfiguration : IEntityTypeConfiguration<Book>
{
    // public Guid Book1Guid { get; private set; } = Guid.NewGuid();
    // public Guid Book2Guid { get; private set; } = Guid.NewGuid();
    // public Guid Book3Guid { get; private set; } = Guid.NewGuid();
    // public Guid Book4Guid { get; private set; } = Guid.NewGuid();
    // public Guid Book5Guid { get; private set; } = Guid.NewGuid();

    public Guid Book1Guid { get; } = Guid.Parse("11111111-1111-1111-1111-111111111111");
    public Guid Book2Guid { get; } = Guid.Parse("22222222-2222-2222-2222-222222222222");
    public Guid Book3Guid { get; } = Guid.Parse("33333333-3333-3333-3333-333333333333");
    public Guid Book4Guid { get; } = Guid.Parse("44444444-4444-4444-4444-444444444444");
    public Guid Book5Guid { get; } = Guid.Parse("55555555-5555-5555-5555-555555555555");

    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.Property(p => p.Title)
            .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
            .IsRequired();
        builder.Property(p => p.Author)
            .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
            .IsRequired();

        builder.HasData(GetSampleBookData());
    }

    private IEnumerable<Book> GetSampleBookData()
    {
        //     new BookDto(Guid.NewGuid(), "1984", "George Orwell"),
        //     new BookDto(Guid.NewGuid(), "To Kill a Mockingbird", "Harper Lee"),
        //     new BookDto(Guid.NewGuid(), "Pride and Prejudice", "Jane Austen"),
        //     new BookDto(Guid.NewGuid(), "The Great Gatsby", "F. Scott Fitzgerald"),
        //     new BookDto(Guid.NewGuid(), "Brave New World", "Aldous Huxley")

        var tolkien = "George Orwell";

        yield return new Book(Book1Guid, "To Kill a Mockingbird", tolkien, 10.99m);
        yield return new Book(Book2Guid, "Pride and Prejudice", tolkien, 10.99m);
        yield return new Book(Book3Guid, "The Great Gatsby", tolkien, 11.99m);
        yield return new Book(Book4Guid, "Brave New World", tolkien, 12.99m);
        yield return new Book(Book5Guid, "The Return of the King", tolkien, 13.99m);

    }
}
