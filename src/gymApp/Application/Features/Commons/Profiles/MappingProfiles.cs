using Application.Features.Commons.Commands.CommonCreateCommonBodyInformation;
using Application.Features.Commons.Commands.CommonUpdateCommonBodyInformation;
using Application.Features.Commons.Dtos;
using Application.Features.Commons.Models;
using Application.Features.Commons.Queries.GetCommonStudentById;
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

            CreateMap<IPaginate<UsersMovement>, CommonUserMovementListModel>().ReverseMap();
            CreateMap<UsersMovement, CommonUserMovementListDto>().ReverseMap();

            CreateMap<IPaginate<PersonalTrainerStudent>, CommonPersonalTrainerStudentListModel>().ReverseMap();
            CreateMap<PersonalTrainerStudent, CommonPersonalTrainerStudentListDto>().ReverseMap();

            CreateMap<IPaginate<UsersMovement>,CommonStudentMovementListByStudentIdAndSelectedDayModel>().ReverseMap();
            CreateMap<UsersMovement, CommonStudentMovementListByStudentIdAndSelectedDayDto>().ReverseMap();

            CreateMap<User, CommonStudentByIdDto>().ReverseMap();
            CreateMap<User, GetCommonStudentByIdQuery>().ReverseMap();

            CreateMap<BodyInformation, CommonUpdateBodyInformationDto>().ReverseMap();
            CreateMap<BodyInformation, UpdateCommonBodyInformationCommand>().ReverseMap();

            CreateMap<BodyInformation, CommonCreateBodyInformationDto>().ReverseMap();
            CreateMap<BodyInformation, CreateCommonBodyInformationCommand>().ReverseMap();
        }
    }
}
