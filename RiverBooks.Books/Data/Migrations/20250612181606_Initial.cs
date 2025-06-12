using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RiverBooks.Books.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Books");

            migrationBuilder.CreateTable(
                name: "Books",
                schema: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Books",
                table: "Books",
                columns: new[] { "Id", "Author", "Price", "Title" },
                values: new object[,]
                {
                    { new Guid("043a3287-d2f7-4b7c-bacb-73ddd86e42cd"), "George Orwell", 13.99m, "The Return of the King" },
                    { new Guid("2ed0b8c5-3148-49df-adbc-d1f3a3380adc"), "George Orwell", 10.99m, "Pride and Prejudice" },
                    { new Guid("42f1fe39-2f71-4668-9528-412f5d4c047e"), "George Orwell", 10.99m, "To Kill a Mockingbird" },
                    { new Guid("72653917-c237-4fe5-a0c1-150e44691c3b"), "George Orwell", 12.99m, "Brave New World" },
                    { new Guid("ec502ffd-a3ec-411a-9071-fa2122981d82"), "George Orwell", 11.99m, "The Great Gatsby" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books",
                schema: "Books");
        }
    }
}
