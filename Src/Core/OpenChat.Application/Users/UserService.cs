using System;
using OpenChat.Common;
using OpenChat.Domain.Entities;

namespace OpenChat.Application.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IGuidGenerator guidGenerator;

        public UserService(IUserRepository userRepository, IGuidGenerator guidGenerator)
        {
            this.userRepository = userRepository;
            this.guidGenerator = guidGenerator;
        }

        public RegisteredUserViewModel RegisterUser(RegistrationInputModel registrationInputModel)
        {
            if(userRepository.IsUsernameInUse(registrationInputModel.Username))
                throw  new UsernameAlreadyInUseException();

            var user = new User
            {
                Id = guidGenerator.Next(),
                Username = registrationInputModel.Username,
                Password = registrationInputModel.Password,
                About = registrationInputModel.About
            };

            userRepository.Add(user);

            return new RegisteredUserViewModel()
            {
                Id = user.Id,
                Username = user.Username,
                About = user.About
            };
        }
    }
}