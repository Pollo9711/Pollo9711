using System;
using ForumProject.Biz.Domain;

namespace ForumProject.Biz.Interfaces.Repositories
{
    public interface IPostRepository : IDetachRepository, ICreateRepository<PostDomain>, IDeleteRepository<PostDomain>, IReadRepository<PostDomain, Guid>, IUpdateRepository<PostDomain>
    {
        
    }
}