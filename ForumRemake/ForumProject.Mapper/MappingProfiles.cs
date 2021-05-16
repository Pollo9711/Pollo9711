using System;
using System.Linq;
using AutoMapper;
using ForumProject.Biz.Domain;
using ForumProject.Dal.Context.Dto;
using ForumProject.Dal.Context.Entities;

namespace ForumProject.Mapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<MessageCreationDto, MessageDomain>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.PublishTime, opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<PostCreationDto, PostDomain>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.PublishTime, opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<UserCreationDto, UserDomain>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.RegisteredOn, opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<MessageEntity, MessageDomain>()
                .ReverseMap();

            CreateMap<PostEntity, PostDomain>()
                .ReverseMap();

            CreateMap<UserEntity, UserDomain>()
                .ReverseMap();
        }
    }
}
