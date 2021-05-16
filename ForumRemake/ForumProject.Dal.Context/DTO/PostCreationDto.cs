using System;
using System.Collections.Generic;
using System.Text;

namespace ForumProject.Dal.Context.Dto
{
    public class PostCreationDto
    {
        public string Title { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public Guid UserId { get; set; }
    }
}
