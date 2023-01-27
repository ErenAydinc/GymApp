using Application.Features.Movements.Dtos;
using Application.Features.Movements.Models;
using Application.Features.Movements.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Movements.Queries.GetMovementList
{
    public class GetMovementListQuery:IRequest<MovementListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetMovementListQueryHandler : IRequestHandler<GetMovementListQuery, MovementListModel>
        {
            private readonly IMovementRepository _movementRepository;
            private readonly IUserRepository _userRepository;
            private readonly MovementBusinessRules _movementBusinessRules;
            private readonly IMapper _mapper;

            public GetMovementListQueryHandler(IMovementRepository movementRepository, MovementBusinessRules movementBusinessRules, IMapper mapper, IUserRepository userRepository)
            {
                _movementRepository = movementRepository;
                _movementBusinessRules = movementBusinessRules;
                _mapper = mapper;
                _userRepository = userRepository;
            }

            public async Task<MovementListModel> Handle(GetMovementListQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Movement> movement = await _movementRepository.GetListAsync(index: request.PageRequest.Page -1, size: request.PageRequest.PageSize);
                MovementListModel mappedMovementListModel = _mapper.Map<MovementListModel>(movement);
                return mappedMovementListModel;
            }
        }
    }
}
