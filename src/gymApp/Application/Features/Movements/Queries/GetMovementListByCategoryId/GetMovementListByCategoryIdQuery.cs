using Application.Constants;
using Application.Features.Movements.Constants;
using Application.Features.Movements.Models;
using Application.Features.Movements.Rules;
using Application.Helpers;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using Domain.MappingEntities;
using MediatR;

namespace Application.Features.Movements.Queries.GetMovementByCustomerList
{
    public class GetMovementListByCategoryIdQuery : IRequest<MovementListByCategoryIdModel>,ISecuredRequest
    {
        public PageRequest PageRequest { get; set; }
        public int CategoryId { get; set; }
        public string[] Roles { get; } =
        {
            GeneralRoles.SystemAdmin,
            GeneralRoles.GymAdmin,
            GeneralRoles.PersonalTrainer
        };
        public class GetMovementListByCategoryIdQueryHandler : IRequestHandler<GetMovementListByCategoryIdQuery, MovementListByCategoryIdModel>
        {
            private readonly IMovementRepository _movementRepository;

            private readonly MovementBusinessRules _movementBusinessRules;
            private readonly IMovementImageRepository _movementImageRepository;
            private readonly ICustomerToMovementMappingRepository _customerToMovementMappingRepository;
            private readonly IHelperService _helperService;
            private readonly IMapper _mapper;

            public GetMovementListByCategoryIdQueryHandler(IMovementRepository movementRepository, MovementBusinessRules movementBusinessRules, IMapper mapper, IMovementImageRepository movementImageRepository, ICustomerToMovementMappingRepository customerToMovementMappingRepository, IHelperService helperService)
            {
                _movementRepository = movementRepository;
                _movementBusinessRules = movementBusinessRules;
                _mapper = mapper;
                _movementImageRepository = movementImageRepository;
                _customerToMovementMappingRepository = customerToMovementMappingRepository;
                _helperService = helperService;
            }

            public async Task<MovementListByCategoryIdModel> Handle(GetMovementListByCategoryIdQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Movement> movements = await _movementRepository.GetListAsync(predicate:request.CategoryId>0?x=>x.CategoryId==request.CategoryId:null, index: request.PageRequest.Page - 1, size: request.PageRequest.PageSize);

                MovementListByCategoryIdModel mappedMovementListByCategoryIdModel = _mapper.Map<MovementListByCategoryIdModel>(movements);

                foreach (var movementsByCategoryId in mappedMovementListByCategoryIdModel.Items)
                {
                    var movementImagebyMovementId = await _movementImageRepository.GetAllAsync(x => x.MovementId == movementsByCategoryId.Id);

                    movementsByCategoryId.MovementImage = movementImagebyMovementId;
                }


                return mappedMovementListByCategoryIdModel;
            }
        }
    }
}
