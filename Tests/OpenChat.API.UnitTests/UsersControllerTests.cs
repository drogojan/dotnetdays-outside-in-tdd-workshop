using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OpenChat.API.Controllers;
using OpenChat.Application.Users;
using Xunit;

namespace OpenChat.API.UnitTests
{
    public class UsersControllerTests
    {
        [Fact]
        public async Task Post_Should_Return_The_Newly_Created_User()
        {
            var userRequest = new UserRequest();
            var expectedResponse = new UserResponse();
            var userServiceMock = new Mock<IUserService>();
            var userController = new UsersController(userServiceMock.Object);

            var response = await userController.Post(userRequest) as CreatedResult;
            var userResponse = response?.Value as UserResponse;

            response?.Value.Should().BeOfType<UserResponse>();
            userResponse.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public async Task Post_Should_Invoke_UserService()
        {
            var userServiceMock = new Mock<IUserService>();
            
            var userRequest = new UserRequest();
            var userController = new UsersController(userServiceMock.Object);

            await userController.Post(userRequest);

            userServiceMock.Verify(us => us.AddUser(userRequest));
        }
    }
}