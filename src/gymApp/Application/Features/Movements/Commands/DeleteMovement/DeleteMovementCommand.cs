using Application.Constants;
using Application.Features.Movements.Constants;
using Application.Features.Movements.Dtos;
using Application.Features.Movements.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using Domain.MappingEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Movements.Commands.DeleteMovement
{
    public class DeleteMovementCommand:IRequest<DeleteMovementDto>,ISecuredRequest
    {
        public int Id { get; set; }

        public string[] Roles { get; } =
        {
            GeneralRoles.SystemAdmin,
        };

        public class DeleteMovementCommandHandler : IRequestHandler<DeleteMovementCommand, DeleteMovementDto>
        {
            private readonly IMovementRepository _movementRepository;
            private readonly ICustomerToMovementMappingRepository _customerToMovementMappingRepository;
            private readonly MovementBusinessRules _movementBusinessRules;
            private readonly IMapper _mapper;

            public DeleteMovementCommandHandler(IMovementRepository movementRepository, MovementBusinessRules movementBusinessRules, IMapper mapper, ICustomerToMovementMappingRepository customerToMovementMappingRepository)
            {
                _movementRepository = movementRepository;
                _movementBusinessRules = movementBusinessRules;
                _mapper = mapper;
                _customerToMovementMappingRepository = customerToMovementMappingRepository;
            }

            public async Task<DeleteMovementDto> Handle(DeleteMovementCommand request, CancellationToken cancellationToken)
            {
                await _movementBusinessRules.MovementNotAlreadyExists(request.Id);
                
                Movement? mappedMovement = _mapper.Map<Movement>(request);

                Movement deleteMovement = await _movementRepository.DeleteAsync(mappedMovement);

                CustomerToMovementMapping? customerToMovementMapping = await _customerToMovementMappingRepository.GetAsync(x => x.MovementId == deleteMovement.Id);

                await _customerToMovementMappingRepository.DeleteAsync(customerToMovementMapping);

                DeleteMovementDto deleteMovementDto =_mapper.Map<DeleteMovementDto>(deleteMovement);

                return deleteMovementDto;
            }
        }
    }
}
