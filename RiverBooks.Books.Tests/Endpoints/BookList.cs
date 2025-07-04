using FastEndpoints;
using FastEndpoints.Testing;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using Xunit.Abstractions;


namespace RiverBooks.Books.Tests.Endpoints
{
    public class BookList(Fixture fixture, ITestOutputHelper outputHelper) : TestBase<Fixture>(fixture, outputHelper)
    {
        [Fact]
        public async Task ReturnsThreeBooksAsync()
        {
            var testResult = await Fixture.Client.GETAsync<List, ListResponse>();

            testResult.Response.EnsureSuccessStatusCode();
            testResult.Result.Books.Count.Should().Be(7);

        }

       
    }

   
}
