﻿using System;
using System.Collections.Generic;
using ForumProject.Biz.Domain;
using ForumProject.Biz.Domain.Exceptions;
using ForumProject.Biz.Interfaces.Repositories;
using ForumProject.Biz.Interfaces.Services;

namespace ForumProject.Biz.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _repository;

        public MessageService(IMessageRepository repository)
        {
            _repository = repository;
        }

        public void Add(MessageDomain element)
        {
            if (element is null)
                throw new InvalidInputException("element");

            if (_repository.GetById(element.Id) != null)
                throw new DbRuleException(element.Id.ToString());

            _repository.Add(element);
        }

        public MessageDomain DeleteById(Guid id)
        {
            var toDelete = _repository.GetById(id);
            if (toDelete is null)
                throw new DbRuleException(id.ToString());

            _repository.DetachAllEntities();
            _repository.Delete(toDelete);

            return toDelete;
        }

        public List<MessageDomain> GetAll()
        {
            return _repository.GetAll();
        }

        public MessageDomain GetById(Guid id)
        {
            var toGet = _repository.GetById(id);
            if (toGet is null)
                throw new DbRuleException(id.ToString());

            return toGet;
        }

        public void Update(MessageDomain entity)
        {
            if (entity is null)
                throw new InvalidInputException("input");

            var toUpdate = _repository.GetById(entity.Id);
            if (toUpdate is null)
                throw new DbRuleException("input");

            _repository.DetachAllEntities();
            _repository.Update(entity);
        }
    }
}