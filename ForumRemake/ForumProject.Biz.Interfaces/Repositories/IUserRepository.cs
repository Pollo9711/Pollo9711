using System;
using System.Threading.Tasks;
using ForumProject.Biz.Domain;

namespace ForumProject.Biz.Interfaces.Repositories
{
    public interface IUserRepository : IDetachRepository, IReadRepository<UserDomain, Guid>, IUpdateRepository<UserDomain>, ICreateRepository<UserDomain>, IDeleteRepository<UserDomain>
    {
        Task<UserDomain> GetByCredentials(string username, string password);
    }
}