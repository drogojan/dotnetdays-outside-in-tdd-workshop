using System;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OpenChat.API.Controllers;
using OpenChat.Application.Common;
using OpenChat.Application.Users;
using Xunit;

namespace OpenChat.API.UnitTests
{
    public class UsersControllerTests
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
            Mock<IUserService> userServiceMock = new Mock<IUserService>();

            var sut = new UsersController(userServiceMock.Object);
            
            sut.RegisterUser(registrationInputModel);

            userServiceMock.Verify(m => m.RegisterUser(registrationInputModel), Times.Once);
        }

        [Fact]
        public void Returns_the_newly_created_user()
        {
            Mock<IUserService> userServiceStub = new Mock<IUserService>();
            RegisteredUserViewModel registeredUserViewModel = new RegisteredUserViewModel()
            {
                Id = Guid.NewGuid(),
                Username = "john",
                About = "About John"
            };
            userServiceStub
                .Setup(m => m.RegisterUser(registrationInputModel))
                .Returns(registeredUserViewModel);

            var sut = new UsersController(userServiceStub.Object);
            var response = sut.RegisterUser(registrationInputModel);

            var createdResult = response as CreatedResult;
            createdResult.Should().NotBeNull();

            var actualCreatedUser = createdResult.Value as RegisteredUserViewModel;
            actualCreatedUser.Should().NotBeNull();

            // actualCreatedUser.Should().Be(registeredUserViewModel);
            // actualCreatedUser.Should().BeEquivalentTo(registeredUserViewModel);

            actualCreatedUser.Username.Should().Be(registrationInputModel.Username);
            actualCreatedUser.About.Should().Be(registrationInputModel.About);
            actualCreatedUser.Id.Should().Be(registeredUserViewModel.Id);
        }

        [Fact]
        public void Returns_an_error_when_trying_to_create_a_user_with_an_existing_username()
        {
            Mock<IUserService> userServiceStub = new Mock<IUserService>();
            userServiceStub.Setup(m => m.RegisterUser(registrationInputModel))
                .Throws<UsernameAlreadyInUseException>();

            var sut = new UsersController(userServiceStub.Object);

            var response = sut.RegisterUser(registrationInputModel);
            var badRequestObjectResult = response as BadRequestObjectResult;

            badRequestObjectResult.Should().NotBeNull();

            var error = badRequestObjectResult.Value as ApiError;
            error.Should().NotBeNull();
            error.Message.Should().Be("Username already in use");
        }
    }
}