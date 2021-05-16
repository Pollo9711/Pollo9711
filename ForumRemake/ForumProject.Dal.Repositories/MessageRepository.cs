using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task Add(MessageDomain element)
        {
            var toAdd = _mapper.Map<MessageEntity>(element);
            await _context.Messages.AddAsync(toAdd);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(MessageDomain entity)
        {
            var toDelete = _mapper.Map<MessageEntity>(entity);
            _context.Messages.Remove(toDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<List<MessageDomain>> GetAll()
        {
            var toConvert = _context.Messages;
            return await _mapper.ProjectTo<MessageDomain>(toConvert).ToListAsync();
        }

        public async Task<MessageDomain> GetById(Guid id)
        {
            var toConvert = await _context.Messages
                .FirstOrDefaultAsync(m => m.Id.Equals(id));
            return _mapper.Map<MessageDomain>(toConvert);
        }

        public async Task Update(MessageDomain entity)
        {
            var toUpdate = _mapper.Map<MessageEntity>(entity);
            _context.Messages.Update(toUpdate);
            await _context.SaveChangesAsync();
        }

        public async Task DetachAllEntities()
        {
            await Task.Run(() => { 
                foreach (var entry in _context.ChangeTracker.Entries())
                {
                    entry.State = EntityState.Detached;
                }
            });
        }
    }
}