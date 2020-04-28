using Xunit;
using Xunit.Abstractions;
using AspNetCore.Http.Extensions;
using System.Threading.Tasks;
using FluentAssertions;
using System.Net;
using Newtonsoft.Json.Linq;
using System;

namespace OpenChat.API.AcceptanceTests
{
    public class UsersTests : ApiTests
    {
        public UsersTests(
            AcceptanceTestFixture testFixture,
            ITestOutputHelper testOutputHelper) 
        : base(testFixture, testOutputHelper)
        {

        }

        [Fact]
        public async Task RegisterUser() {
            var data = new
            {
                username = "Mihai",
                password = "mihaidojo",
                about = "my first coding dojo"
            };
            var post = await client.PostAsJsonAsync("api/users", data);

            post.StatusCode.Should().Be(HttpStatusCode.Created);

            var content = await post.Content.ReadAsJsonAsync<JObject>();

            content.Value<string>("username").Should().Be(data.username);
            content.Value<string>("about").Should().Be(data.about);
            Guid.Parse(content.Value<string>("id")).Should().NotBeEmpty();
        }
    }
}