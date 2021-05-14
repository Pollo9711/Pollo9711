using System;
using ForumProject.Biz.Domain;

namespace ForumProject.Api.ViewModels
{
    public class UserDto
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public UserDto(UserDomain user)
        {
            Username = user.Username;
            Password = user.Password;
            Email = user.Email;
        }

    }
}