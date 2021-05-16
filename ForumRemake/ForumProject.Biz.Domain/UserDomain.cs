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

        public DateTime? BanTime { get; set; }

        public DateTime RegisteredOn { get; set; }

        public List<PostDomain> Posts { get; set; }
    }
}