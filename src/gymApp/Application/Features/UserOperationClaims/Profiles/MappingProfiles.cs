using Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;
using Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaim;
using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Models;
using Application.Features.UserOperationClaims.Queries.GetUserOperationClaimById;
using Application.Features.UserOperationClaims.Queries.GetUserOperationClaimList;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;

namespace Application.Features.UserUserOperationClaims.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserOperationClaim, CreateUserOperationClaimDto>().ReverseMap();
            CreateMap<UserOperationClaim, CreateUserOperationClaimCommand>().ReverseMap();

            CreateMap<UserOperationClaim, UpdateUserOperationClaimDto>().ReverseMap();
            CreateMap<UserOperationClaim, UpdateUserOperationClaimCommand>().ReverseMap();

            CreateMap<UserOperationClaim, DeleteUserOperationClaimDto>().ReverseMap();
            CreateMap<UserOperationClaim, DeleteUserOperationClaimCommand>().ReverseMap();

            CreateMap<UserOperationClaim, GetUserOperationClaimByIdDto>().ReverseMap();
            CreateMap<UserOperationClaim, GetUserOperationClaimByIdQuery>().ReverseMap();

            CreateMap<IPaginate<UserOperationClaim>, UserOperationClaimListModel>().ReverseMap();
            CreateMap<UserOperationClaim, GetUserOperationClaimListDto>().ReverseMap();

            CreateMap<IPaginate<UserOperationClaim>, UserOperationClaimListByUserIdModel>().ReverseMap();
            CreateMap<UserOperationClaim, GetUserOperationClaimListByUserIdDto>().ReverseMap();

        }
    }
}
