using FastEndpoints;
using FastEndpoints.Testing;
using FluentAssertions;
using Xunit;

namespace RiverBooks.Books.Tests.Endpoints
{
    public class BookGetById(Fixture Fixture)
        : TestBase<Fixture>
    {
        [Theory]
        [InlineData("55555555-5555-5555-5555-555555555555", "The Return of the King")]
        [InlineData("22222222-2222-2222-2222-222222222222", "Pride and Prejudice")]
        public async Task ReturnsExpectedBookGivenIdAsync(string validId, string expectedTitle)
        {
            Guid id = Guid.Parse(validId);
            var request = new GetByIdRequest { Id = id };
            var testResult = await Fixture.Client.GETAsync <GetById, GetByIdRequest, BookDto>(request);

            testResult.Response.EnsureSuccessStatusCode();
            testResult.Result.Title.Should().Be(expectedTitle);


        }
    }



}
