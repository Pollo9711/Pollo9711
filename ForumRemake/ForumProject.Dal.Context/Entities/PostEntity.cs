using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ForumProject.Biz.Domain;

namespace ForumProject.Dal.Context.Entities
{
    public class PostEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public CategoryEnum Category { get; set; }

        [Required]
        public string Description { get; set; }

        public int PostPoint { get; set; }

        public bool IsClosed { get; set; }

        [Required]
        public DateTime PublishTime { get; set; }

        public virtual List<MessageEntity> Messages { get; set; }

    }
}