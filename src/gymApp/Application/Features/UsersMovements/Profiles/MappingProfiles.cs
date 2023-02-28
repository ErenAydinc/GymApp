using Application.Features.UsersMovements.Commands.CreateUsersMovement;
using Application.Features.UsersMovements.Commands.DeleteUsersMovement;
using Application.Features.UsersMovements.Commands.UpdateUsersMovement;
using Application.Features.UsersMovements.Dtos;
using Application.Features.UsersMovements.Models;
using Application.Features.UsersMovements.Queries.GetUsersMovementById;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.UsersMovements.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<UsersMovement, CreateUsersMovementDto>().ReverseMap();
            CreateMap<UsersMovement, CreateUsersMovementCommand>().ReverseMap();

            CreateMap<UsersMovement, UpdateUsersMovementDto>().ReverseMap();
            CreateMap<UsersMovement, UpdateUsersMovementCommand>().ReverseMap();

            CreateMap<UsersMovement, DeleteUsersMovementDto>().ReverseMap();
            CreateMap<UsersMovement, DeleteUsersMovementCommand>().ReverseMap();

            CreateMap<UsersMovement, GetUsersMovementByIdDto>().ReverseMap();
            CreateMap<UsersMovement, GetUsersMovementByIdQuery>().ReverseMap();

            CreateMap<IPaginate<UsersMovement>, UsersMovementListModel>().ReverseMap();
            CreateMap<UsersMovement, GetUsersMovementListDto>().ReverseMap();

            CreateMap<IPaginate<UsersMovement>, UsersMovementsListByUserIdModel>().ReverseMap();
            CreateMap<UsersMovement, GetUsersMovementsByUserIdDto>().ReverseMap();

            CreateMap<IPaginate<UsersMovement>, UsersMovementsListByUserIdAndSelectedDayModel>().ReverseMap();
            CreateMap<UsersMovement, GetUsersMovementsByUserIdAndSelectedDayDto>().ReverseMap();
        }
    }
}
