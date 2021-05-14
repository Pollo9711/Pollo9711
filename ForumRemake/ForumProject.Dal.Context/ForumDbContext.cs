using System;
using ForumProject.Dal.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace ForumProject.Dal.Context
{
    public class ForumDbContext : DbContext
    {
        public ForumDbContext(DbContextOptions<ForumDbContext> options) : base(options)
        {
            
        }

        public virtual DbSet<MessageEntity> Messages { get; set; }
        public virtual DbSet<PostEntity> Posts { get; set; }
        public virtual DbSet<UserEntity> Users { get; set; }

    }
}
