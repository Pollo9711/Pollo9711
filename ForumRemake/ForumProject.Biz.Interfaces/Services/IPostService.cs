using System;
using System.Collections.Generic;
using ForumProject.Biz.Domain;

namespace ForumProject.Biz.Interfaces.Services
{
    public interface IPostService
    {
        public void Add(PostDomain element);

        public PostDomain DeleteById(Guid id);

        public List<PostDomain> GetAll();

        public PostDomain GetById(Guid id);

        public void Update(PostDomain entity);
    }
}