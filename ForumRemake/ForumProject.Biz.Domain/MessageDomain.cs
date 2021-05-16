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

        public Guid WrittenBy { get; set; }

        public Guid PostId { get; set; }

    }
}
