using Application.Features.Movements.Constants;
using Application.Features.Movements.Dtos;
using Application.Features.Movements.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Movements.Commands.UpdateMovement
{
    public class UpdateMovementCommand:IRequest<UpdateMovementDto>,ISecuredRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string[] Roles { get; } =
        {
            MovementRoles.MovementAdmin,
            MovementRoles.MovementUpdate
        };

        public class UpdateMovementCommandHandler : IRequestHandler<UpdateMovementCommand, UpdateMovementDto>
        {
            private readonly IMovementRepository _movementRepository;
            private readonly MovementBusinessRules _movementBusinessRules;
            private readonly IMapper _mapper;

            public UpdateMovementCommandHandler(IMovementRepository movementRepository, MovementBusinessRules movementBusinessRules, IMapper mapper)
            {
                _movementRepository = movementRepository;
                _movementBusinessRules = movementBusinessRules;
                _mapper = mapper;
            }

            public async Task<UpdateMovementDto> Handle(UpdateMovementCommand request, CancellationToken cancellationToken)
            {
                await _movementBusinessRules.MovementNotAlreadyExists(request.Id);
                await _movementBusinessRules.MovementAlreadyExists(request.Id);
                
                Movement? mappedMovement = _mapper.Map<Movement>(request);

                Movement updateMovement = await _movementRepository.UpdateAsync(mappedMovement);

                UpdateMovementDto updateMovementDto =_mapper.Map<UpdateMovementDto>(updateMovement);

                return updateMovementDto;
            }
        }
    }
}
