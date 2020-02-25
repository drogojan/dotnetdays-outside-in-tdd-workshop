using System;
using FluentAssertions;
using Moq;
using OpenChat.Application.Users;
using OpenChat.Common;
using OpenChat.Domain.Entities;
using Xunit;

namespace OpenChat.Application.UnitTests
{
    public class UserServiceTests
    {
        RegistrationInputModel registrationInputModel = new RegistrationInputModel()
        {
            Username = "john",
            Password = "john123",
            About = "About John"
        };

        [Fact]
        public void Create_a_user()
        {
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            Mock<IGuidGenerator> guidGeneratorStub = new Mock<IGuidGenerator>();
            var userId = Guid.NewGuid();
            guidGeneratorStub.Setup(m => m.Next()).Returns(userId);

            var sut = new UserService(userRepositoryMock.Object, guidGeneratorStub.Object);
            var registeredUser = sut.RegisterUser(registrationInputModel);

            userRepositoryMock.Verify(m => m.Add(It.Is<User>(
                u => u.Id == userId
                     && u.Username == registrationInputModel.Username
                     && u.Password == registrationInputModel.Password
                     && u.About == registrationInputModel.About
                )));

            registeredUser.Id.Should().Be(userId);
            registeredUser.Username.Should().Be(registrationInputModel.Username);
            registeredUser.About.Should().Be(registrationInputModel.About);
        }

        [Fact]
        public void Throws_UsernameAlreadyInUseException_when_creating_a_user_with_an_existing_username()
        {
            Mock<IUserRepository> userRepositoryStub = new Mock<IUserRepository>();
            userRepositoryStub.Setup(m => m.IsUsernameInUse(registrationInputModel.Username)).Returns(true);

            Mock<IGuidGenerator> guidGeneratorDummy = new Mock<IGuidGenerator>();
            var sut = new UserService(userRepositoryStub.Object, guidGeneratorDummy.Object);

            Action action = () => sut.RegisterUser(registrationInputModel);

            action.Should().Throw<UsernameAlreadyInUseException>().WithMessage("Username already in use");
        }
    }
}