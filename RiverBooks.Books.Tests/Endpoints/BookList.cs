using System.Threading.Tasks;
using FastEndpoints;
using FastEndpoints.Testing;
using FluentAssertions;
using Xunit;

namespace RiverBooks.Books.Tests.Endpoints
{
    public class BookList(Fixture Fixture) 
        : TestBase<Fixture>
    {
        [Fact]
        public async Task ReturnsThreeBooksAsync()
        {
            var testResult = await Fixture.Client.GETAsync<List, ListResponse>();

            testResult.Response.EnsureSuccessStatusCode();
            testResult.Result.Books.Count.Should().Be(5);

        }

       
    }



}
