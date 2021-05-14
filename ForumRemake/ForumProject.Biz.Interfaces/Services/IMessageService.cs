using System;
using System.Collections.Generic;
using ForumProject.Biz.Domain;

namespace ForumProject.Biz.Interfaces.Services
{
    public interface IMessageService
    {
        public void Add(MessageDomain element);

        public MessageDomain DeleteById(Guid id);

        public List<MessageDomain> GetAll();

        public MessageDomain GetById(Guid id);

        public void Update(MessageDomain entity);
    }
}