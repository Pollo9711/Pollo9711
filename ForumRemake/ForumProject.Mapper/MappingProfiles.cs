using System;
using AutoMapper;
using ForumProject.Biz.Domain;
using ForumProject.Dal.Context.Entities;

namespace ForumProject.Mapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<MessageDomain, MessageEntity>()
                .ReverseMap();

            CreateMap<PostDomain, PostEntity>()
                .ReverseMap();

            CreateMap<UserDomain, UserEntity>()
                .ReverseMap();
        }
    }
}
