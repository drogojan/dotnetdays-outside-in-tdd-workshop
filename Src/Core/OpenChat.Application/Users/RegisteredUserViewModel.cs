using System;

namespace OpenChat.Application.Users
{
    public class RegisteredUserViewModel
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string About { get; set; }
    }
}