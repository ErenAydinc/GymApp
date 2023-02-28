using Application.Features.Users.Commands.CreateUser;
using Application.Features.Users.Dtos;
using Application.Features.Users.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;

namespace Application.Features.Users.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, CreateUserCommand>().ReverseMap();

            CreateMap<User, CreateUserDto>().ReverseMap();

            CreateMap<User, UpdateUserDto>().ReverseMap();

            CreateMap<User, DeleteUserDto>().ReverseMap();

            CreateMap<User,GetUserByIdDto>().ReverseMap();

            CreateMap<IPaginate<User>, UserListModel>().ReverseMap();

            CreateMap<User, GetUserListDto>().ReverseMap();

            CreateMap<IPaginate<User>, UserByCustomerListModel>().ReverseMap();

            CreateMap<User, GetUserByCustomerIdDto>().ReverseMap();

            CreateMap<IPaginate<User>, PersonalTrainerListModel>().ReverseMap();

            CreateMap<User, GetPersonalTrainerListDto>().ReverseMap();

            CreateMap<IPaginate<User>, StudentListModel>().ReverseMap();

            CreateMap<User, GetStudentListDto>().ReverseMap();

            CreateMap<IPaginate<User>, DeleteStudentListModel>().ReverseMap();

            CreateMap<User, GetDeleteStudentListDto>().ReverseMap();
        }
    }
}
