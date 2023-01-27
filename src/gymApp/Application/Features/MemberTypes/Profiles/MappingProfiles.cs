using Application.Features.MemberTypes.Commands.CreateMemberType;
using Application.Features.MemberTypes.Commands.DeleteMemberType;
using Application.Features.MemberTypes.Commands.UpdateMemberType;
using Application.Features.MemberTypes.Dtos;
using Application.Features.MemberTypes.Models;
using Application.Features.MemberTypes.Queries.GetMemberTypeById;
using Application.Features.MemberTypes.Queries.GetMemberTypeList;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MemberTypes.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<MemberType, CreateMemberTypeDto>().ReverseMap();
            CreateMap<MemberType, CreateMemberTypeCommand>().ReverseMap();

            CreateMap<MemberType, UpdateMemberTypeDto>().ReverseMap();
            CreateMap<MemberType, UpdateMemberTypeCommand>().ReverseMap();

            CreateMap<MemberType, DeleteMemberTypeDto>().ReverseMap();
            CreateMap<MemberType, DeleteMemberTypeCommand>().ReverseMap();

            CreateMap<MemberType, GetMemberTypeByIdDto>().ReverseMap();
            CreateMap<MemberType, GetMemberTypeByIdQuery>().ReverseMap();

            CreateMap<IPaginate<MemberType>, MemberTypeListModel>().ReverseMap();
            CreateMap<MemberType, GetMemberTypeListDto>().ReverseMap();
        }
    }
}
