using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task Add(MessageDomain element)
        {
            if (element is null)
                throw new InvalidInputException("element");

            if (await _repository.GetById(element.Id) != null)
                throw new DbRuleException(element.Id.ToString());

            await _repository.Add(element);
        }

        public async Task<MessageDomain> DeleteById(Guid id)
        {
            var toDelete = await _repository.GetById(id);
            if (toDelete is null)
                throw new DbRuleException(id.ToString());

            await _repository.DetachAllEntities();
            await _repository.Delete(toDelete);

            return toDelete;
        }

        public async Task<List<MessageDomain>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<MessageDomain> GetById(Guid id)
        {
            var toGet = await _repository.GetById(id);
            if (toGet is null)
                throw new DbRuleException(id.ToString());

            return toGet;
        }

        public async Task Update(MessageDomain entity)
        {
            if (entity is null)
                throw new InvalidInputException("input");

            var toUpdate = await _repository.GetById(entity.Id);
            if (toUpdate is null)
                throw new DbRuleException("input");

            await _repository.DetachAllEntities();
            await _repository.Update(entity);
        }
    }
}