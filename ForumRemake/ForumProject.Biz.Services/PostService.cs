using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ForumProject.Biz.Domain;
using ForumProject.Biz.Domain.Exceptions;
using ForumProject.Biz.Interfaces.Repositories;
using ForumProject.Biz.Interfaces.Services;

namespace ForumProject.Biz.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _repository;

        public PostService(IPostRepository repository)
        {
            _repository = repository;
        }

        public async Task Add(PostDomain element)
        {
            if (element is null)
                throw new InvalidInputException("element");

            if (await _repository.GetById(element.Id) != null)
                throw new DbRuleException(element.Id.ToString());

            await _repository.Add(element);
        }

        public async Task<PostDomain> DeleteById(Guid id)
        {
            var toDelete = await _repository.GetById(id);
            if (toDelete is null)
                throw new DbRuleException(id.ToString());

            await _repository.DetachAllEntities();
            await _repository.Delete(toDelete);

            return toDelete;
        }

        public async Task<List<PostDomain>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<List<PostDomain>> GetByCategory(string category)
        {
            if (category == string.Empty)
                throw new InvalidInputException("input");
            return await _repository.GetByCategory(category);
        }

        public async Task<PostDomain> GetById(Guid id)
        {
            var toGet = await _repository.GetById(id);
            if (toGet is null)
                throw new DbRuleException(id.ToString());

            return toGet;
        }

        public async Task<List<PostDomain>> GetByTitle(string title)
        {
            if (title == string.Empty)
                throw new InvalidInputException("input");
            return await _repository.GetByTitle(title);
        }

        public async Task Update(PostDomain entity)
        {
            if (entity is null)
                throw new InvalidInputException("input");

            var toUpdate = _repository.GetById(entity.Id);
            if (toUpdate is null)
                throw new DbRuleException("input");

            await _repository.DetachAllEntities();
            await _repository.Update(entity);
        }
    }
}