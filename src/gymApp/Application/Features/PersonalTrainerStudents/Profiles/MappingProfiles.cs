using Application.Features.PersonalTrainerStudents.Commands.CreatePersonalTrainerStudent;
using Application.Features.PersonalTrainerStudents.Commands.DeletePersonalTrainerStudent;
using Application.Features.PersonalTrainerStudents.Commands.UpdatePersonalTrainerStudent;
using Application.Features.PersonalTrainerStudents.Dtos;
using Application.Features.PersonalTrainerStudents.Models;
using Application.Features.PersonalTrainerStudents.Queries.GetPersonalTrainerStudentById;
using Application.Features.PersonalTrainerStudents.Queries.GetPersonalTrainerStudentByStudentId;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.PersonalTrainerStudents.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<PersonalTrainerStudent, CreatePersonalTrainerStudentDto>().ReverseMap();
            CreateMap<PersonalTrainerStudent, CreatePersonalTrainerStudentCommand>().ReverseMap();

            CreateMap<PersonalTrainerStudent, UpdatePersonalTrainerStudentDto>().ReverseMap();
            CreateMap<PersonalTrainerStudent, UpdatePersonalTrainerStudentCommand>().ReverseMap();

            CreateMap<PersonalTrainerStudent, DeletePersonalTrainerStudentDto>().ReverseMap();
            CreateMap<PersonalTrainerStudent, DeletePersonalTrainerStudentCommand>().ReverseMap();

            CreateMap<PersonalTrainerStudent, GetPersonalTrainerStudentByIdDto>().ReverseMap();
            CreateMap<PersonalTrainerStudent, GetPersonalTrainerStudentByIdQuery>().ReverseMap();

            CreateMap<PersonalTrainerStudent, GetPersonalTrainerStudentByStudentIdDto>().ReverseMap();
            CreateMap<PersonalTrainerStudent, GetPersonalTrainerStudentByStudentIdQuery>().ReverseMap();

            CreateMap<IPaginate<PersonalTrainerStudent>, PersonalTrainerStudentListModel>().ReverseMap();
            CreateMap<PersonalTrainerStudent, GetPersonalTrainerStudentListDto>().ReverseMap();

            CreateMap<IPaginate<PersonalTrainerStudent>, PersonalTrainerStudentListByPersonalTrainerIdModel>().ReverseMap();
            CreateMap<PersonalTrainerStudent, GetPersonalTrainerStudentListByPersonalTrainerIdDto>().ReverseMap();
        }
    }
}
