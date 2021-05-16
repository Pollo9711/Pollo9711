using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ForumProject.Biz.Domain;
using ForumProject.Biz.Domain.Exceptions;
using ForumProject.Biz.Interfaces.Repositories;
using ForumProject.Biz.Interfaces.Services;

namespace ForumProject.Biz.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<UserDomain>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<UserDomain> GetById(Guid id)
        {
            var toGet = await _repository.GetById(id);
            if (toGet is null)
                throw new DbRuleException(id.ToString());

            return toGet;
        }

        public async Task Update(UserDomain entity)
        {
            if (entity is null)
                throw new InvalidInputException("input");

            var toUpdate = _repository.GetById(entity.Id);
            if (toUpdate is null)
                throw new DbRuleException("input");

            await _repository.DetachAllEntities();
            await _repository.Update(entity);
        }

        public async Task Add(UserDomain element)
        {
            if (element is null)
                throw new InvalidInputException("input");

            if (await _repository.GetById(element.Id) != null)
                throw new DbRuleException("input");

            await _repository.Add(element);
        }

        public async Task<UserDomain> DeleteById(Guid id)
        {
            var toDelete = await _repository.GetById(id);
            if (toDelete is null)
                throw new DbRuleException("input");

            await _repository.DetachAllEntities();
            await _repository.Delete(toDelete);
            return toDelete;
        }

        public async Task<UserDomain> Login(string username, string password)
        {
            if (username == string.Empty || password == string.Empty)
                throw new InvalidInputException("input");
            return await _repository.GetByCredentials(username, password);
        }
    }
}
