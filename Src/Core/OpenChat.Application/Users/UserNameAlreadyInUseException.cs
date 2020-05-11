using System;

namespace OpenChat.Application.Users
{
    public class UserNameAlreadyInUseException : Exception
    {
        public override string Message { get; }

        public UserNameAlreadyInUseException(string message)
        {
            Message = message;
        }
    }
}