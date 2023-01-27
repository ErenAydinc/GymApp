using Application.Features.MovementImageUploadMappings.Commands.CreateMovementImageUploadMapping;
using Application.Features.MovementImageUploadMappings.Commands.DeleteMovementImageUploadMapping;
using Application.Features.MovementImageUploadMappings.Commands.UpdateMovementImageUploadMapping;
using Application.Features.MovementImageUploadMappings.Dtos;
using Application.Features.MovementImageUploadMappings.Models;
using Application.Features.MovementImageUploadMappings.Queries.GetMovementImageUploadMappingById;
using Application.Features.MovementImageUploadMappings.Queries.GetMovementImageUploadMappingByMovementId;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.MappingEntities;

namespace Application.Features.MovementImageUploadMappings.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<MovementImageUploadMapping, CreateMovementImageUploadMappingDto>().ReverseMap();
            CreateMap<MovementImageUploadMapping, CreateMovementImageUploadMappingCommand>().ReverseMap();

            CreateMap<MovementImageUploadMapping, UpdateMovementImageUploadMappingDto>().ReverseMap();
            CreateMap<MovementImageUploadMapping, UpdateMovementImageUploadMappingCommand>().ReverseMap();

            CreateMap<MovementImageUploadMapping, DeleteMovementImageUploadMappingDto>().ReverseMap();
            CreateMap<MovementImageUploadMapping, DeleteMovementImageUploadMappingCommand>().ReverseMap();

            CreateMap<MovementImageUploadMapping, GetMovementImageUploadMappingByIdDto>().ReverseMap();
            CreateMap<MovementImageUploadMapping, GetMovementImageUploadMappingByIdQuery>().ReverseMap();

            CreateMap<MovementImageUploadMapping, GetMovementImageUploadMappingByMovementIdDto>().ReverseMap();
            CreateMap<MovementImageUploadMapping, GetMovementImageUploadMappingByMovementIdQuery>().ReverseMap();

            CreateMap<IPaginate<MovementImageUploadMapping>, MovementImageUploadMappingListModel>().ReverseMap();
            CreateMap<MovementImageUploadMapping, GetMovementImageUploadMappingListDto>().ReverseMap();
        }
    }
}
