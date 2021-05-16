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
    public class UserRepository : IUserRepository
    {
        private readonly ForumDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(ForumDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<UserDomain>> GetAll()
        {
            var toConvert = _context.Users;
            return await _mapper.ProjectTo<UserDomain>(toConvert).ToListAsync();
        }

        public async Task<UserDomain> GetById(Guid id)
        {
            var toConvert = await _context.Users
                .Include(u => u.Posts)
                .FirstOrDefaultAsync(u => u.Id.Equals(id));
            return _mapper.Map<UserDomain>(toConvert);
        }

        public async Task Update(UserDomain entity)
        {
            var toUpdate = _mapper.Map<UserEntity>(entity);
            _context.Users.Update(toUpdate);
            await _context.SaveChangesAsync();
        }

        public async Task Add(UserDomain element)
        {
            var toAdd = _mapper.Map<UserEntity>(element);
            await _context.Users.AddAsync(toAdd);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(UserDomain entity)
        {
            var toDelete = _mapper.Map<UserEntity>(entity);
            _context.Users.Remove(toDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<UserDomain> GetByCredentials(string username, string password)
        {
            var toReturn = await _context.Users.FirstOrDefaultAsync(u => u.Username.Equals(username) && u.Password.Equals(password));
            return _mapper.Map<UserDomain>(toReturn);
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
