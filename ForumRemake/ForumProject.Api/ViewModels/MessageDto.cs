using System;
using ForumProject.Biz.Domain;

namespace ForumProject.Api.ViewModels
{
    public class MessageDto
    {
        public string Text { get; set; }

        public DateTime PublishTime { get; set; }

        public Guid Post { get; set; }

        public Guid User { get; set; }

        public MessageDto(MessageDomain message)
        {
            Text = message.Text;
            PublishTime = message.PublishTime;
            Post = message.PostId;
            User = message.UserId;
        }
    }
}