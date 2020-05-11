using System.Threading.Tasks;

namespace OpenChat.Application.Users
{
    public interface IUserService
    {
        Task<UserResponse> AddUserAsync(UserRequest userRequest);
    }
}