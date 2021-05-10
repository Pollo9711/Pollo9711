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
    public class PostRepository : IPostRepository
    {
        private readonly ForumDbContext _context;
        private readonly IMapper _mapper;

        public PostRepository(ForumDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Add(PostDomain element)
        {
            var toAdd = _mapper.Map<PostEntity>(element);
            _context.Posts.Add(toAdd);
            _context.SaveChanges();
        }

        public void Delete(PostDomain entity)
        {
            var toAdd = _mapper.Map<PostEntity>(entity);
            _context.Posts.Remove(toAdd);
            _context.SaveChanges();
        }

        public List<PostDomain> GetAll()
        {
            var toConvert = _context.Posts;
            return _mapper.ProjectTo<PostDomain>(toConvert).ToList();
        }

        public PostDomain GetById(Guid id)
        {
            var toConvert = _context.Posts
                .Include(p => p.Messages)
                .FirstOrDefault(p => p.Id.Equals(id));
            return _mapper.Map<PostDomain>(toConvert);
        }

        public void Update(PostDomain entity)
        {
            var toAdd = _mapper.Map<PostEntity>(entity);
            _context.Posts.Update(toAdd);
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