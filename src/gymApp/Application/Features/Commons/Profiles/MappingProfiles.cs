using Application.Features.Commons.Dtos;
using Application.Features.Commons.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Domain.Entities;

namespace Application.Features.Commons.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<IPaginate<User>, CommonStudentListModel>().ReverseMap();
            CreateMap<User, CommonStudentListDto>().ReverseMap();

            CreateMap<IPaginate<User>, CommonPersonalTrainerListModel>().ReverseMap();
            CreateMap<User, CommonPersonalTrainerListDto>().ReverseMap();

            CreateMap<IPaginate<Movement>, CommonMovementListModel>().ReverseMap();
            CreateMap<Movement, CommonMovementListDto>().ReverseMap();
        }
    }
}
