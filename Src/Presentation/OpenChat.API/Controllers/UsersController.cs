using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenChat.API.Models;
using OpenChat.Application.Users;

namespace OpenChat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Post(UserRequest userRequest)
        {
            UserResponse user;
            try
            {
                user = await _userService.AddUserAsync(userRequest);
            }
            catch (UserNameAlreadyInUseException exception)
            {
                var errorResponse = new ErrorResponse(exception.Message);
                return new BadRequestObjectResult(errorResponse);
            }

            return new CreatedResult($"/api/users/{user.Id}", user);
        }
    }
}