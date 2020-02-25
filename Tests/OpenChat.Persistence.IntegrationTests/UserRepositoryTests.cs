using System;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using OpenChat.Domain.Entities;
using Xunit;
using Xunit.Abstractions;

namespace OpenChat.Persistence.IntegrationTests
{
    public class UserRepositoryTests : RepositoryIntegrationTests
    {

        [Fact]
        public void Reports_when_a_username_is_already_in_use()
        {
            User john = new User() {Id = Guid.NewGuid(), Username = "john", Password = "john123", About = "About John"};
            User marie = new User() {Id = Guid.NewGuid(), Username = "marie", Password = "marie456", About = "About Marie"};

            var sut = new UserRepository(DbContext);

            sut.Add(john);

            sut.IsUsernameInUse(john.Username).Should().Be(true);
            sut.IsUsernameInUse(marie.Username).Should().Be(false);
        }


        public UserRepositoryTests(DbMigrationFixture dbMigrationFixture, ITestOutputHelper testOutputHelper) : base(dbMigrationFixture, testOutputHelper)
        {
        }
    }
}