using Application.Features.Users.Dtos;
using Application.Features.Users.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UpdateUserDto>().ReverseMap();

            CreateMap<User,GetUserByIdDto>().ReverseMap();

            CreateMap<IPaginate<User>, UserListModel>().ReverseMap();

            CreateMap<User, GetUserListDto>().ReverseMap();
        }
    }
}
