using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ForumProject.Dal.Context.Entities
{
    public class UserEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public DateTime BanTime { get; set; }

        public virtual List<MessageEntity> Messages { get; set; }

    }
}