using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ForumProject.Biz.Domain;

namespace ForumProject.Biz.Interfaces.Services
{
    public interface IUserService
    { 
        Task<List<UserDomain>> GetAll();

        Task<UserDomain> GetById(Guid id);

        Task Update(UserDomain entity);

        Task Add(UserDomain element);

        Task<UserDomain> DeleteById(Guid id);

        Task<UserDomain> Login(string username, string password);
    }
}