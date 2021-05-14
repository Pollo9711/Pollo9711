using System;
using System.Collections.Generic;
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

        public List<UserDomain> GetAll()
        {
            return _repository.GetAll();
        }

        public UserDomain GetById(Guid id)
        {
            var toGet = _repository.GetById(id);
            if (toGet is null)
                throw new DbRuleException(id.ToString());

            return toGet;
        }

        public void Update(UserDomain entity)
        {
            if (entity is null)
                throw new InvalidInputException("input");

            var toUpdate = _repository.GetById(entity.Id);
            if (toUpdate is null)
                throw new DbRuleException("input");

            _repository.DetachAllEntities();
            _repository.Update(entity);
        }

        public void Add(UserDomain element)
        {
            if (element is null)
                throw new InvalidInputException("input");

            if (_repository.GetById(element.Id) != null)
                throw new DbRuleException("input");

            _repository.Add(element);
        }

        public UserDomain DeleteById(Guid id)
        {
            var toDelete = _repository.GetById(id);
            if (toDelete is null)
                throw new DbRuleException("input");

            _repository.DetachAllEntities();
            _repository.Delete(toDelete);
            return toDelete;
        }
    }
}
