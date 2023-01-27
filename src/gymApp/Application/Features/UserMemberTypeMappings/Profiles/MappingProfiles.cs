using Application.Features.UserMemberTypeMappings.Commands.CreateUserMemberTypeMapping;
using Application.Features.UserMemberTypeMappings.Commands.DeleteUserMemberTypeMapping;
using Application.Features.UserMemberTypeMappings.Commands.UpdateUserMemberTypeMapping;
using Application.Features.UserMemberTypeMappings.Dtos;
using Application.Features.UserMemberTypeMappings.Models;
using Application.Features.UserMemberTypeMappings.Queries.GetUserMemberTypeMappingById;
using Application.Features.UserMemberTypeMappings.Queries.GetUserMemberTypeMappingList;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using Domain.MappingEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserMemberTypeMappings.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserMemberTypeMapping, CreateUserMemberTypeMappingDto>().ReverseMap();
            CreateMap<UserMemberTypeMapping, CreateUserMemberTypeMappingCommand>().ReverseMap();

            CreateMap<UserMemberTypeMapping, UpdateUserMemberTypeMappingDto>().ReverseMap();
            CreateMap<UserMemberTypeMapping, UpdateUserMemberTypeMappingCommand>().ReverseMap();

            CreateMap<UserMemberTypeMapping, DeleteUserMemberTypeMappingDto>().ReverseMap();
            CreateMap<UserMemberTypeMapping, DeleteUserMemberTypeMappingCommand>().ReverseMap();

            CreateMap<UserMemberTypeMapping, GetUserMemberTypeMappingByIdDto>().ReverseMap();
            CreateMap<UserMemberTypeMapping, GetUserMemberTypeMappingByIdQuery>().ReverseMap();

            CreateMap<IPaginate<UserMemberTypeMapping>, UserMemberTypeMappingListModel>().ReverseMap();
            CreateMap<UserMemberTypeMapping, GetUserMemberTypeMappingListDto>().ReverseMap();
        }
    }
}
