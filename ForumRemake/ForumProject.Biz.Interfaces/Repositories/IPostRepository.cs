using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ForumProject.Biz.Domain;

namespace ForumProject.Biz.Interfaces.Repositories
{
    public interface IPostRepository : IDetachRepository, ICreateRepository<PostDomain>, IDeleteRepository<PostDomain>, IReadRepository<PostDomain, Guid>, IUpdateRepository<PostDomain>
    {
        Task<List<PostDomain>> GetByTitle(string title);

        Task<List<PostDomain>> GetByCategory(string category);
    }
}