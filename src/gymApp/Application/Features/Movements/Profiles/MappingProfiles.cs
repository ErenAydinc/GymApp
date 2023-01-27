using Application.Features.Movements.Commands.CreateMovement;
using Application.Features.Movements.Commands.DeleteMovement;
using Application.Features.Movements.Commands.UpdateMovement;
using Application.Features.Movements.Dtos;
using Application.Features.Movements.Models;
using Application.Features.Movements.Queries.GetMovementById;
using Application.Features.Movements.Queries.GetMovementList;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Movements.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Movement, CreateMovementDto>().ReverseMap();
            CreateMap<Movement, CreateMovementCommand>().ReverseMap();

            CreateMap<Movement, UpdateMovementDto>().ReverseMap();
            CreateMap<Movement, UpdateMovementCommand>().ReverseMap();

            CreateMap<Movement, DeleteMovementDto>().ReverseMap();
            CreateMap<Movement, DeleteMovementCommand>().ReverseMap();

            CreateMap<Movement,GetMovementByIdDto>().ReverseMap();
            CreateMap<Movement, GetMovementByIdQuery>().ReverseMap();

            CreateMap<IPaginate<Movement>, MovementListModel>().ReverseMap();
            CreateMap<Movement, GetMovementListDto>().ReverseMap();
        }
    }
}
