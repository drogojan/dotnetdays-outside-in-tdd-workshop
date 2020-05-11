using System;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OpenChat.API.Controllers;
using OpenChat.API.Models;
using OpenChat.Application.Users;
using Xunit;

namespace OpenChat.API.UnitTests
{
    public class UsersControllerTests
    {
        // [Fact]
        // public async Task Post_Should_Invoke_UserService()
        // {
        //     var userServiceMock = new Mock<IUserService>();

        //     var userRequest = new UserRequest();
        //     var userController = new UsersController(userServiceMock.Object);

        //     await userController.Post(userRequest);

        //     userServiceMock.Verify(us => us.AddUserAsync(userRequest));
        // }

        [Fact]
        public async Task Post_Should_Return_The_Newly_Created_User()
        {
            var userRequest = new UserRequest();
            userRequest.Username = "username";
            userRequest.Password = "pwd";
            userRequest.About = "about";

            var expectedResponse = new UserResponse();
            expectedResponse.Username = userRequest.Username;
            expectedResponse.About = userRequest.About;
            expectedResponse.Id = Guid.Empty.ToString();

            var userServiceMock = new Mock<IUserService>();
            var userController = new UsersController(userServiceMock.Object);

            userServiceMock.Setup(service => service.AddUserAsync(userRequest)).ReturnsAsync(expectedResponse);
            var response = await userController.Post(userRequest) as CreatedResult;
            var actualResponse = response?.Value as UserResponse;

            response?.Value.Should().BeOfType<UserResponse>();
            actualResponse.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public async Task Post_Should_Return_Error_Response_If_Username_Already_In_Use()
        {
            var userRequest = new UserRequest()
            {
                Username = "username",
                Password = "pwd",
                About = "about"
            };
            var userServiceMock = new Mock<IUserService>();
            var userController = new UsersController(userServiceMock.Object);
            var expectedErrorMessage = "Username already in use.";
            var expectedException = new UserNameAlreadyInUseException(expectedErrorMessage);

            userServiceMock.Setup(service => service.AddUserAsync(userRequest)).ThrowsAsync(expectedException);

            var response = await userController.Post(userRequest) as BadRequestObjectResult;
            var actualResponse = response?.Value as ErrorResponse;

            response?.Value.Should().BeOfType<ErrorResponse>();
            actualResponse.Message.Should().Be(expectedErrorMessage);
        }
    }
}