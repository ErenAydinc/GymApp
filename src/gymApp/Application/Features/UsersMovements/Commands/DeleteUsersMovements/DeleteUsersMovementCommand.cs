using Application.Constants;
using Application.Features.UsersMovements.Constants;
using Application.Features.UsersMovements.Dtos;
using Application.Features.UsersMovements.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;

namespace Application.Features.UsersMovements.Commands.DeleteUsersMovement
{
    public class DeleteUsersMovementCommand:IRequest<DeleteUsersMovementDto>,ISecuredRequest
    {
        public int Id { get; set; }
        public string[] Roles { get; } =
        {
            GeneralRoles.SystemAdmin,
            GeneralRoles.GymAdmin,
            GeneralRoles.PersonalTrainer
        };

        public class DeleteUsersMovementCommandHandler : IRequestHandler<DeleteUsersMovementCommand, DeleteUsersMovementDto>
        {
            private readonly IUsersMovementRepository _usersMovementRepository;
            private readonly UsersMovementBusinessRules _usersMovementBusinessRules;
            private readonly IMapper _mapper;

            public DeleteUsersMovementCommandHandler(IUsersMovementRepository usersMovementRepository, UsersMovementBusinessRules usersMovementBusinessRules, IMapper mapper)
            {
                _usersMovementRepository = usersMovementRepository;
                _usersMovementBusinessRules = usersMovementBusinessRules;
                _mapper = mapper;
            }

            public async Task<DeleteUsersMovementDto> Handle(DeleteUsersMovementCommand request, CancellationToken cancellationToken)
            {
                await _usersMovementBusinessRules.UsersMovementNotExists(request.Id);

                UsersMovement? usersMovement = _mapper.Map<UsersMovement>(request);

                UsersMovement? mappedUsersMovement = await _usersMovementRepository.DeleteAsync(usersMovement);

                DeleteUsersMovementDto deleteUsersMovementDto = _mapper.Map<DeleteUsersMovementDto>(mappedUsersMovement);

                return deleteUsersMovementDto;
            }
        }
    }
}
