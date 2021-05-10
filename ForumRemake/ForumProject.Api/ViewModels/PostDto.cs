using System;
using System.Collections.Generic;
using ForumProject.Biz.Domain;
using ForumProject.Dal.Context.Entities;

namespace ForumProject.Api.ViewModels
{
    public class PostDto
    {
        public PostDto()
        {
            
        }

        public string Title { get; set; }

        public CategoryEnum Category { get; set; }

        public string Description { get; set; }

        public DateTime PublishTime { get; set; }

        public PostDto(PostDomain post)
        {
            Title = post.Title;
            Category = post.Category;
            Description = post.Description;
            PublishTime = post.PublishTime;
        }
    }
}