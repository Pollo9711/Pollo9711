using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using AutoMapper;
using ForumProject.Biz.Domain;
using ForumProject.Biz.Interfaces.Repositories;
using ForumProject.Dal.Context;
using ForumProject.Dal.Context.Entities;
using Xunit;

namespace ForumProject.Dal.Tests
{
    public class PostRepositoryTests
    {
        private readonly IMapper _mapper;
        private readonly ForumDbContext _ctx;
        private readonly IPostRepository _repo;

        public PostRepositoryTests(IMapper mapper, ForumDbContext context, IPostRepository repo)
        {
            _mapper = mapper;
            _ctx = context;
            _repo = repo;
        }

        /*[Fact]
        public void GetById_InputPostDomainIsValid_Returns_PostDomain()
        {
            using (var transaction = new TransactionScope())
            {
                UserEntity userino = new UserEntity()
                {
                    Id = Guid.NewGuid(),
                    Email = "userino@test.com",
                    Password = "heheheh",
                    Username = "userino89"
                };

                _ctx.Users.Add(userino);
                _ctx.SaveChanges();

                PostEntity postino = new PostEntity()
                {
                    Id = Guid.NewGuid(),
                    Messages = null,
                    Title = "None of your business",
                    Description = "lalala",
                    Category = CategoryEnum.None,
                    User = userino,
                    PublishTime = DateTime.Now
                };

                _ctx.Posts.Add(postino);
                _ctx.SaveChanges();

                var result = _repo.GetById(postino.Id);

                Assert.NotNull(result);
                Assert.IsType<PostDomain>(result);
            }
        }

        [Fact]
        public void GetById_PostNotFound_ReturnsNull()
        {
            Assert.Null(_repo.GetById(Guid.NewGuid()));

            _ctx.Database.EnsureDeleted();
        }

        [Fact]
        public void Add_InputPostDomainIsValid_No_Returns()
        {
            using (var transaction = new TransactionScope())
            {
                UserEntity userino = new UserEntity()
                {
                    Id = Guid.NewGuid(),
                    Email = "userino@test.com",
                    Password = "heheheh",
                    Username = "userino89"
                };

                _ctx.Users.Add(userino);
                _ctx.SaveChanges();

                PostEntity postino = new PostEntity()
                {
                    Id = Guid.NewGuid(),
                    Messages = null,
                    Title = "None of your business",
                    Description = "lalala",
                    Category = CategoryEnum.None,
                    User = userino,
                    PublishTime = DateTime.Now
                };

                _ctx.Posts.Add(postino);
                _ctx.SaveChanges();

                var result = _ctx.Posts.FirstOrDefault(p => p.Id.Equals(postino.Id));

                Assert.NotNull(result);
                Assert.IsType<PostEntity>(result);
            }
        }

        [Fact]
        public void DeleteById_InputGuidIsValid_NoReturns()
        {
            using (var transaction = new TransactionScope())
            {
                UserEntity userino = new UserEntity()
                {
                    Id = Guid.NewGuid(),
                    Email = "userino@test.com",
                    Password = "heheheh",
                    Username = "userino89"
                };

                _ctx.Users.Add(userino);
                _ctx.SaveChanges();

                PostEntity postino = new PostEntity()
                {
                    Id = Guid.NewGuid(),
                    Messages = null,
                    Title = "None of your business",
                    Description = "lalala",
                    Category = CategoryEnum.None,
                    User = userino,
                    PublishTime = DateTime.Now
                };

                _ctx.Posts.Add(postino);
                _ctx.SaveChanges();

                var toDelete = _mapper.Map<PostDomain>(postino);
                _repo.DeleteById(toDelete.Id);
                _ctx.SaveChanges();

                var toTest = _ctx.Posts.FirstOrDefault(p => p.Id == postino.Id);

                Assert.Null(toTest);
            }
        }

        [Fact]
        public void GetAll_NoInput_ReturnsPostDomainIEnumerable()
        {

            using (var transaction = new TransactionScope())
            {
                UserEntity userino = new UserEntity()
                {
                    Id = Guid.NewGuid(),
                    Email = "userino@test.com",
                    Password = "heheheh",
                    Username = "userino89"
                };

                _ctx.Users.Add(userino);
                _ctx.SaveChanges();

                PostEntity postino = new PostEntity()
                {
                    Id = Guid.NewGuid(),
                    Messages = null,
                    Title = "None of your business",
                    Description = "lalala",
                    Category = CategoryEnum.None,
                    User = userino,
                    PublishTime = DateTime.Now
                };

                PostEntity postino2 = new PostEntity()
                {
                    Id = Guid.NewGuid(),
                    Messages = null,
                    Title = "None of your business",
                    Description = "lalala",
                    Category = CategoryEnum.None,
                    User = userino,
                    PublishTime = DateTime.Now
                };

                _ctx.Posts.Add(postino);
                _ctx.SaveChanges();

                _ctx.Posts.Add(postino);
                _ctx.Posts.Add(postino2);
                _ctx.SaveChanges();

                var result = _repo.GetAll();

                Assert.IsAssignableFrom<IEnumerable<PostDomain>>(result);
                Assert.NotEmpty(result);
            }
        }

        [Fact]
        public void GetAll_NoInput_ReturnsEmptyIEnumerable()
        {
            using (var transaction = new TransactionScope())
            {
                var toTest = _repo.GetAll();

                Assert.Empty(toTest);
            }
        }*/
    }
}
