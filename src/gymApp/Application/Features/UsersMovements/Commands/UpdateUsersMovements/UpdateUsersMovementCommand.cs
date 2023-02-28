using Application.Constants;
using Application.Features.UsersMovements.Constants;
using Application.Features.UsersMovements.Dtos;
using Application.Features.UsersMovements.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;

namespace Application.Features.UsersMovements.Commands.UpdateUsersMovement
{
    public class UpdateUsersMovementCommand:IRequest<UpdateUsersMovementDto>,ISecuredRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MovementId { get; set; }
        public int SetNumber { get; set; }
        public int RepetitionNumber { get; set; }
        public int Weight { get; set; }
        public bool IsMonday { get; set; }
        public bool IsTuesday { get; set; }
        public bool IsWednesday { get; set; }
        public bool IsThursday { get; set; }
        public bool IsFriday { get; set; }
        public bool IsSaturday { get; set; }
        public bool IsSunday { get; set; }
        public string[] Roles { get; } =
        {
            GeneralRoles.SystemAdmin,
            GeneralRoles.GymAdmin,
            GeneralRoles.PersonalTrainer
        };

        public class UpdateUsersMovementCommandHandler : IRequestHandler<UpdateUsersMovementCommand, UpdateUsersMovementDto>
        {
            private readonly IUsersMovementRepository _usersMovementRepository;
            private readonly UsersMovementBusinessRules _usersMovementBusinessRules;
            private readonly IMapper _mapper;
            public UpdateUsersMovementCommandHandler(IUsersMovementRepository usersMovementRepository, UsersMovementBusinessRules usersMovementBusinessRules, IMapper mapper)
            {
                _usersMovementRepository = usersMovementRepository;
                _usersMovementBusinessRules = usersMovementBusinessRules;
                _mapper = mapper;
            }
            public async Task<UpdateUsersMovementDto> Handle(UpdateUsersMovementCommand request, CancellationToken cancellationToken)
            {
                await _usersMovementBusinessRules.UsersMovementNotExists(request.Id);

                await _usersMovementBusinessRules.UserIdNotExists(request.UserId);

                await _usersMovementBusinessRules.MovementNotExists(request.MovementId);

                UsersMovement? usersMovement = _mapper.Map<UsersMovement>(request);

                UsersMovement mappedUsersMovement = await _usersMovementRepository.UpdateAsync(usersMovement);

                UpdateUsersMovementDto updateUsersMovementDto = _mapper.Map<UpdateUsersMovementDto>(mappedUsersMovement);

                return updateUsersMovementDto;
            }
        }
    }
}
