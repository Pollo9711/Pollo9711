using System;
using System.Collections.Generic;
using System.Text;

namespace ForumProject.Dal.Context.Dto
{
    public class MessageCreationDto
    {
        public string Text { get; set; }

        public Guid WrittenBy { get; set; }

        public Guid PostId { get; set; }
    }
}
