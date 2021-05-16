using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ForumProject.Biz.Domain;

namespace ForumProject.Biz.Interfaces.Services
{
    public interface IMessageService
    {
        Task Add(MessageDomain element);

        Task<MessageDomain> DeleteById(Guid id);

        Task<List<MessageDomain>> GetAll();

        Task<MessageDomain> GetById(Guid id);

        Task Update(MessageDomain entity);
    }
}