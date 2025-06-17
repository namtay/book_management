using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RiverBooks.Books.Data.Migrations
{
    /// <inheritdoc />
    public partial class Changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Books",
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("043a3287-d2f7-4b7c-bacb-73ddd86e42cd"));

            migrationBuilder.DeleteData(
                schema: "Books",
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("2ed0b8c5-3148-49df-adbc-d1f3a3380adc"));

            migrationBuilder.DeleteData(
                schema: "Books",
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("42f1fe39-2f71-4668-9528-412f5d4c047e"));

            migrationBuilder.DeleteData(
                schema: "Books",
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("72653917-c237-4fe5-a0c1-150e44691c3b"));

            migrationBuilder.DeleteData(
                schema: "Books",
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ec502ffd-a3ec-411a-9071-fa2122981d82"));

            migrationBuilder.InsertData(
                schema: "Books",
                table: "Books",
                columns: new[] { "Id", "Author", "Price", "Title" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "George Orwell", 10.99m, "To Kill a Mockingbird" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "George Orwell", 10.99m, "Pride and Prejudice" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "George Orwell", 11.99m, "The Great Gatsby" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), "George Orwell", 12.99m, "Brave New World" },
                    { new Guid("55555555-5555-5555-5555-555555555555"), "George Orwell", 13.99m, "The Return of the King" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Books",
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                schema: "Books",
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                schema: "Books",
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                schema: "Books",
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                schema: "Books",
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"));

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
    }
}
