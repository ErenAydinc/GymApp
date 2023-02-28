using Application.Constants;
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

namespace Application.Features.Movements.Queries.GetMovementById
{
    public class GetMovementByIdQuery:IRequest<GetMovementByIdDto>,ISecuredRequest
    {
        public int Id { get; set; }

        public string[] Roles { get; } =
        {
            GeneralRoles.SystemAdmin,
            GeneralRoles.GymAdmin,
            GeneralRoles.PersonalTrainer
        };
        public class GetMovementByIdQueryHandler:IRequestHandler<GetMovementByIdQuery, GetMovementByIdDto>
        {
            private readonly IMovementRepository _movementRepository;
            private readonly MovementBusinessRules _movementBusinessRules;
            private readonly IMapper _mapper;

            public GetMovementByIdQueryHandler(IMovementRepository movementRepository, MovementBusinessRules movementBusinessRules, IMapper mapper)
            {
                _movementRepository = movementRepository;
                _movementBusinessRules = movementBusinessRules;
                _mapper = mapper;
            }

            public async Task<GetMovementByIdDto> Handle(GetMovementByIdQuery request, CancellationToken cancellationToken)
            {
                await _movementBusinessRules.MovementNotAlreadyExists(request.Id);

                Movement? movement= await _movementRepository.GetAsync(x => x.Id == request.Id);

                GetMovementByIdDto getMovementByIdDto = _mapper.Map<GetMovementByIdDto>(movement);

                return getMovementByIdDto;
            }
        }
    }
}
