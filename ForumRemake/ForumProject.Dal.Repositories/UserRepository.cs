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
    public class UserRepository : IUserRepository
    {
        private readonly ForumDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(ForumDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<UserDomain> GetAll()
        {
            var toConvert = _context.Users;
            return _mapper.ProjectTo<UserDomain>(toConvert).ToList();
        }

        public UserDomain GetById(Guid id)
        {
            var toConvert = _context.Users
                .Include(u => u.Messages)
                .FirstOrDefault(u => u.Id.Equals(id));
            return _mapper.Map<UserDomain>(toConvert);
        }

        public void Update(UserDomain entity)
        {
            var toUpdate = _mapper.Map<UserEntity>(entity);
            _context.Users.Update(toUpdate);
            _context.SaveChanges();
        }

        public void Add(UserDomain element)
        {
            var toAdd = _mapper.Map<UserEntity>(element);
            _context.Users.Add(toAdd);
            _context.SaveChanges();
        }

        public void Delete(UserDomain entity)
        {
            var toDelete = _mapper.Map<UserEntity>(entity);
            _context.Users.Remove(toDelete);
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
