using Application.Constants;
using Application.Features.UsersMovements.Constants;
using Application.Features.UsersMovements.Dtos;
using Application.Features.UsersMovements.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using Domain.MappingEntities;
using MediatR;

namespace Application.Features.UsersMovements.Queries.GetUsersMovementById
{
    public class GetUsersMovementByIdQuery:IRequest<GetUsersMovementByIdDto>,ISecuredRequest
    {
        public int Id { get; set; }
        public string[] Roles { get; } =
        {
            GeneralRoles.SystemAdmin,
            GeneralRoles.GymAdmin,
            GeneralRoles.PersonalTrainer
        };
        public class GetUsersMovementByIdQueryHandler : IRequestHandler<GetUsersMovementByIdQuery, GetUsersMovementByIdDto>
        {
            private readonly IUsersMovementRepository _usersMovementRepository;
            private readonly UsersMovementBusinessRules _usersMovementBusinessRules;
            private readonly IMapper _mapper;

            public GetUsersMovementByIdQueryHandler(IUsersMovementRepository usersMovementRepository, UsersMovementBusinessRules usersMovementBusinessRules, IMapper mapper)
            {
                _usersMovementRepository = usersMovementRepository;
                _usersMovementBusinessRules = usersMovementBusinessRules;
                _mapper = mapper;
            }

            public async Task<GetUsersMovementByIdDto> Handle(GetUsersMovementByIdQuery request, CancellationToken cancellationToken)
            {
                await _usersMovementBusinessRules.UsersMovementNotExists(request.Id);

                UsersMovement? usersMovement = await _usersMovementRepository.GetAsync(x=>x.Id == request.Id);

                GetUsersMovementByIdDto getUsersMovementByIdDto=_mapper.Map<GetUsersMovementByIdDto>(usersMovement);

                return getUsersMovementByIdDto;
            }
        }
    }
}
