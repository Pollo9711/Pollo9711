using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ForumProject.Biz.Domain;

namespace ForumProject.Biz.Interfaces.Services
{
    public interface IPostService
    {
        Task Add(PostDomain element);

        Task<PostDomain> DeleteById(Guid id);

        Task<List<PostDomain>> GetAll();

        Task<PostDomain> GetById(Guid id);

        Task Update(PostDomain entity);

        Task<List<PostDomain>> GetByTitle(string title);

        Task<List<PostDomain>> GetByCategory(string category);
    }
}