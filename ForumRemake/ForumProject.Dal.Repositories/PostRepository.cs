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
    public class PostRepository : IPostRepository
    {
        private readonly ForumDbContext _context;
        private readonly IMapper _mapper;

        public PostRepository(ForumDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Add(PostDomain element)
        {
            var toAdd = _mapper.Map<PostEntity>(element);
            await _context.Posts.AddAsync(toAdd);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(PostDomain entity)
        {
            var toAdd = _mapper.Map<PostEntity>(entity);
            _context.Posts.Remove(toAdd);
            await _context.SaveChangesAsync();
        }

        public async Task<List<PostDomain>> GetAll()
        {
            var toConvert = _context.Posts;
            return await _mapper.ProjectTo<PostDomain>(toConvert).ToListAsync();
        }

        public async Task<PostDomain> GetById(Guid id)
        {
            var toConvert = await _context.Posts
                .Include(p => p.Messages)
                .FirstOrDefaultAsync(p => p.Id.Equals(id));
            return _mapper.Map<PostDomain>(toConvert);
        }

        public async Task Update(PostDomain entity)
        {
            var toAdd = _mapper.Map<PostEntity>(entity);
            _context.Posts.Update(toAdd);
            await _context.SaveChangesAsync();
        }

        public async Task<List<PostDomain>> GetByTitle(string title)
        {
            var toReturn = _context.Posts;
            return await _mapper.ProjectTo<PostDomain>(toReturn).Where(p => p.Title.Equals(title)).ToListAsync();
        }

        public async Task<List<PostDomain>> GetByCategory(string category)
        {
            var toReturn = _context.Posts;
            return await _mapper.ProjectTo<PostDomain>(toReturn).Where(p => p.Category.Equals(category)).ToListAsync();
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