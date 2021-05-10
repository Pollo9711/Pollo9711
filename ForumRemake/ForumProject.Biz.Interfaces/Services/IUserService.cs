using System;
using System.Collections.Generic;
using ForumProject.Biz.Domain;

namespace ForumProject.Biz.Interfaces.Services
{
    public interface IUserService
    { 
        public List<UserDomain> GetAll();

        public UserDomain GetById(Guid id);

        public void Update(UserDomain entity);

        public void Add(UserDomain element);

        public UserDomain DeleteById(Guid id);
    }
}