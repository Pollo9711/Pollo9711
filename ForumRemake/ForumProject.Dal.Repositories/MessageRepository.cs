using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ForumProject.Biz.Domain;
using ForumProject.Biz.Interfaces.Repositories;
using ForumProject.Dal.Context;
using ForumProject.Dal.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace ForumProject.Dal.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ForumDbContext _context;
        private readonly IMapper _mapper;

        public MessageRepository(ForumDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Add(MessageDomain element)
        {
            var toAdd = _mapper.Map<MessageEntity>(element);
            _context.Messages.Add(toAdd);
            _context.SaveChanges();
        }

        public void Delete(MessageDomain entity)
        {
            var toDelete = _mapper.Map<MessageEntity>(entity);
            _context.Messages.Remove(toDelete);
            _context.SaveChanges();
        }

        public List<MessageDomain> GetAll()
        {
            var toConvert = _context.Messages;
            return _mapper.ProjectTo<MessageDomain>(toConvert).ToList();
        }

        public MessageDomain GetById(Guid id)
        {
            var toConvert = _context.Messages
                .FirstOrDefault(m => m.Id.Equals(id));
            return _mapper.Map<MessageDomain>(toConvert);
        }

        public void Update(MessageDomain entity)
        {
            var toUpdate = _mapper.Map<MessageEntity>(entity);
            _context.Messages.Update(toUpdate);
            _context.SaveChanges();
        }

        public void DetachAllEntities()
        {
            foreach (var entry in _context.ChangeTracker.Entries())
            {
                entry.State = EntityState.Detached;
            }
        }
    }
}