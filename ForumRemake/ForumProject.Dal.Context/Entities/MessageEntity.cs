using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForumProject.Dal.Context.Entities
{
    public class MessageEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Text { get; set; }

        public int MessagePoint { get; set; }

        public bool IsReported { get; set; }

        [Required]
        public DateTime PublishTime { get; set; }

        [ForeignKey("UserId")]
        public UserEntity User { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [ForeignKey("PostId")]
        public PostEntity Post { get; set; }

        [Required]
        public Guid PostId { get; set; }
    }
}