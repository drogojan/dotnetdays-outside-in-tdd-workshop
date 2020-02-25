namespace OpenChat.Application.Users
{
    public interface IUserService
    {
        RegisteredUserViewModel RegisterUser(RegistrationInputModel registrationInputModel);
    }
}