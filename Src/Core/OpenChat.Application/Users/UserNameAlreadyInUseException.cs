using System;

namespace OpenChat.Application.Users
{
    public class UserNameAlreadyInUseException : Exception
    {

        public UserNameAlreadyInUseException(string message) : base(message)
        {
        }
    }
}