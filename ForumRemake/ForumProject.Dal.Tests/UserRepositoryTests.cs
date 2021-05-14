using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using AutoMapper;
using ForumProject.Biz.Domain;
using ForumProject.Biz.Interfaces.Repositories;
using ForumProject.Dal.Context;
using ForumProject.Dal.Context.Entities;
using ForumProject.Dal.Repositories;
using Xunit;

namespace ForumProject.Dal.Tests
{
    public class UserRepositoryTests
    {
        private readonly IMapper _mapper;
        private readonly ForumDbContext _ctx;
        private readonly IUserRepository _repo;

        public UserRepositoryTests(IMapper mapper, ForumDbContext context, IUserRepository repo)
        {
            _mapper = mapper;
            _ctx = context;
            _repo = repo;
        }

        [Fact]
        public void GetById_InputGuidIdIsValid_ReturnsUserDomainObject()
        {
            using (var transaction = new TransactionScope())
            {
                UserEntity tempUser = new UserEntity()
                {
                    Id = Guid.NewGuid(),
                    Email = "userino@test.com",
                    Password = "heheheh",
                    Username = "userino89"
                };

                _ctx.Users.Add(tempUser);
                var entries = _ctx.SaveChanges();

                Assert.Equal(1, entries);

                var toTest = _repo.GetById(tempUser.Id);

                Assert.NotNull(toTest);
                Assert.IsType<UserDomain>(toTest);
                Assert.Equal(tempUser.Id, toTest.Id);
                Assert.Equal(tempUser.Username, toTest.Username);
                Assert.Equal(tempUser.Password, toTest.Password);

                transaction.Complete();
            }
        }

        [Fact]
        public void GetById_InputGuidIdIsNotValid_ReturnsNull()
        {
            var toTest = _repo.GetById(Guid.NewGuid());

            Assert.Null(toTest);

            _ctx.Database.EnsureDeleted();
        }

        [Fact]
        public void GetAll_NoInput_ReturnsIEnumerableOfUserDomainObject()
        {
            using (var transaction = new TransactionScope())
            {
                UserEntity tempUser = new UserEntity()
                {
                    Id = Guid.NewGuid(),
                    Email = "userino@test.com",
                    Password = "heheheh",
                    Username = "userino89"
                };

                UserEntity tempUser2 = new UserEntity()
                {
                    Id = Guid.NewGuid(),
                    Email = "userino2@test.com",
                    Password = "hehehehdsdsds",
                    Username = "userino89dsdsds"
                };

                _ctx.Users.Add(tempUser);
                _ctx.Users.Add(tempUser2);
                var entries = _ctx.SaveChanges();

                Assert.Equal(2, entries);

                var toTest = _repo.GetAll().ToList();

                Assert.Equal(2, toTest.Count());
                Assert.IsType<List<UserDomain>>(toTest);
                Assert.Equal(tempUser.Id, toTest[0].Id);
                Assert.Equal(tempUser.Username, toTest[0].Username);
                Assert.Equal(tempUser.Password, toTest[0].Password);

                transaction.Complete();
            }
        }
    }
}
