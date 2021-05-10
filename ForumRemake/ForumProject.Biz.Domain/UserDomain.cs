using System;
using System.Collections.Generic;

namespace ForumProject.Biz.Domain
{
    public class UserDomain
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public DateTime BanTime { get; set; }

        public List<MessageDomain> Messages { get; set; }
    }
}