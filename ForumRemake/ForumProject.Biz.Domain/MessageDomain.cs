using System;
using System.Collections.Generic;
using System.Text;

namespace ForumProject.Biz.Domain
{
    public class MessageDomain
    {
        public Guid Id { get; set; }

        public string Text { get; set; }

        public int MessagePoint { get; set; }

        public bool IsReported { get; set; }

        public DateTime PublishTime { get; set; }

        public UserDomain User { get; set; }

        public Guid UserId { get; set; }

        public Guid PostId { get; set; }

        public PostDomain Post { get; set; }
    }
}
