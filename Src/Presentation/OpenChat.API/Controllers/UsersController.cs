using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OpenChat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public Task Post() {
            throw new Exception();
        }
    }
}