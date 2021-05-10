using System;
using ForumProject.Biz.Domain;

namespace ForumProject.Biz.Interfaces.Repositories
{
    public interface IMessageRepository : IDetachRepository, ICreateRepository<MessageDomain>, IDeleteRepository<MessageDomain>, IReadRepository<MessageDomain, Guid>, IUpdateRepository<MessageDomain>
    {
        
    }
}