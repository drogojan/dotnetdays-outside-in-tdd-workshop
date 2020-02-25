using System;
using System.Net;
using System.Threading.Tasks;
using AspNetCore.Http.Extensions;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using Xunit;
using Xunit.Abstractions;

namespace OpenChat.API.AcceptanceTests
{
    public class RegistrationApiTests : ApiTests
    {
        [Fact]
        public async Task Register_a_user()
        {
            var user =
            new {
                Username = "john",
                Password = "john123",
                About ="About John"
            };

            var response = await client.PostAsJsonAsync("api/users", user);

            response.StatusCode.Should().Be(HttpStatusCode.Created);

            var createdUser = await response.Content.ReadAsJsonAsync<JObject>();

            createdUser.Value<string>("username").Should().Be(user.Username);
            createdUser.Value<string>("about").Should().Be(user.About);
            Guid.Parse(createdUser.Value<string>("id")).Should().NotBeEmpty();
        }

        public RegistrationApiTests(AcceptanceTestFixture testFixture, ITestOutputHelper testOutputHelper) : base(testFixture, testOutputHelper)
        {
        }
    }
}