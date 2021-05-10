using AutoMapper;
using ForumProject.Biz.Interfaces.Repositories;
using ForumProject.Dal.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using ForumProject.Biz.Domain;
using ForumProject.Dal.Context.Entities;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Xunit;
using System.Linq;

namespace ForumProject.Dal.Tests
{
    public class MessageRepositoryTests
    {
        private readonly IMapper _mapper;
        private readonly ForumDbContext _ctx;
        private readonly IMessageRepository _repo;

        public MessageRepositoryTests(IMapper mapper, ForumDbContext context, IMessageRepository repo)
        {
            _mapper = mapper;
            _ctx = context;
            _repo = repo;
        }

        /*[Fact]
        public void Add_InputMessageDomainObject_NoReturn()
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

                MessageEntity message = new MessageEntity
                {
                    Id = Guid.NewGuid(),
                    Text = "ahahahaha",
                    PublishTime = DateTime.Now,
                    Post = postino,
                    User = userino
                };

                _ctx.Messages.Add(message);
                _ctx.SaveChanges();

                var result = _ctx.Messages.FirstOrDefault(m => m.Id == message.Id);

                Assert.NotNull(result);
                Assert.IsType<Message>(result);
                Assert.Equal(message.Id, result.Id);
                Assert.Equal(message.Text, result.Text);

                transaction.Complete();
            }

        }

        [Fact]
        public void GetAll_NoInput_ReturnsListOfMessages()
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

                MessageEntity message = new MessageEntity
                {
                    Id = Guid.NewGuid(),
                    Text = "ahahahaha",
                    PublishTime = DateTime.Now,
                    Post = postino,
                    User = userino
                };

                MessageEntity message2 = new MessageEntity
                {
                    Id = Guid.NewGuid(),
                    Text = "ahahahaha",
                    PublishTime = DateTime.Now,
                    Post = postino,
                    User = userino
                };

                _ctx.Messages.Add(message);
                _ctx.Messages.Add(message2);
                _ctx.SaveChanges();

                var entries = _ctx.SaveChanges();

                Assert.Equal(2, entries);

                var result = _repo.GetAll().ToList();

                Assert.Equal(2, result.Count());
                Assert.IsType<List<MessageDomain>>(result);
                Assert.NotNull(result);

                transaction.Complete();
            }
        }

        [Fact]
        public void GetById_InputIsValid_ReturnMessageDomain()
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

                MessageEntity message = new MessageEntity
                {
                    Id = Guid.NewGuid(),
                    Text = "ahahahaha",
                    PublishTime = DateTime.Now,
                    Post = postino,
                    User = userino
                };

                _ctx.Messages.Add(message);
                var entries = _ctx.SaveChanges();

                Assert.Equal(1, entries);

                var result = _repo.GetById(message.Id);

                Assert.NotNull(result);
                Assert.IsType<MessageDomain>(result);
                Assert.Equal(message.Id, result.Id);

                transaction.Complete();
            }
        }

        [Fact]
        public void GetById_InputGuidIsNotValid_ReturnsNull()
        {
            var result = _repo.GetById(Guid.NewGuid());

            Assert.Null(result);

            _ctx.Database.EnsureDeleted();
        }

        [Fact]
        public void Delete_InputIsValid_ReturnsNull()
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

                MessageEntity message = new MessageEntity
                {
                    Id = Guid.NewGuid(),
                    Text = "ahahahaha",
                    PublishTime = DateTime.Now,
                    Post = postino,
                    User = userino
                };

                _ctx.Messages.Add(message);
                var entries = _ctx.SaveChanges();

                Assert.Equal(1, entries);

                var messageToDelete = _repo.GetById(message.Id);
                _repo.RejectChanges();

                Assert.NotNull(messageToDelete);

                _repo.DeleteById(messageToDelete.Id);

                var toTest = _ctx.Messages.FirstOrDefault(m => m.Id == messageToDelete.Id);
                Assert.Null(toTest);

                transaction.Complete();
            }
        }

        [Fact]
        public void Update_InputGuidIsValid_ReturnsNull()
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

                MessageEntity message = new MessageEntity
                {
                    Id = Guid.NewGuid(),
                    Text = "ahahahaha",
                    PublishTime = DateTime.Now,
                    Post = postino,
                    User = userino
                };

                _ctx.Messages.Add(message);
                _ctx.SaveChanges();

                message.Text = "provaaaa";

                var messageToUpdate = _repo.GetById(message.Id);
                _repo.Update(messageToUpdate);
                _repo.RejectChanges();

                Assert.Equal(message.Text, messageToUpdate.Text);

                transaction.Complete();
            }
        }*/
    }
}
