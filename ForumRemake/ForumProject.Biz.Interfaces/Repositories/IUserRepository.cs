using System;
using ForumProject.Biz.Domain;

namespace ForumProject.Biz.Interfaces.Repositories
{
    public interface IUserRepository : IDetachRepository, IReadRepository<UserDomain, Guid>, IUpdateRepository<UserDomain>, ICreateRepository<UserDomain>, IDeleteRepository<UserDomain>
    {

    }
}