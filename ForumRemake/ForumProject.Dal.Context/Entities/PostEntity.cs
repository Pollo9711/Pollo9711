using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForumProject.Dal.Context.Entities
{
    public class PostEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Description { get; set; }

        public int PostPoint { get; set; }

        public bool IsClosed { get; set; }

        [Required]
        public DateTime PublishTime { get; set; }

        [ForeignKey("UserId")]
        public UserEntity User { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public List<MessageEntity> Messages { get; set; }

    }
}