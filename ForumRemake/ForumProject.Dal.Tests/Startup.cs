using System;
using System.Collections.Generic;
using System.Text;
using ForumProject.Biz.Interfaces.Repositories;
using ForumProject.Dal.Context;
using ForumProject.Dal.Repositories;
using ForumProject.Mapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ForumProject.Dal.Tests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfiles));

            services.AddDbContext<ForumDbContext>(opt =>
                opt.UseSqlServer("/*connection string*/"));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
        }
    }
}
