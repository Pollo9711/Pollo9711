using System;
using System.Collections.Generic;

namespace ForumProject.Biz.Domain
{
    public class PostDomain
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public CategoryEnum Category { get; set; }

        public string Description { get; set; }

        public int PostPoint { get; set; }

        public bool IsClosed { get; set; }

        public DateTime PublishTime { get; set; }

        public List<MessageDomain> Messages { get; set; }
    }
}
