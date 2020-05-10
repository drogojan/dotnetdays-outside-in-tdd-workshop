using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
            _userService.AddUser(userRequest);

            return Ok();
        }
    }
}