using Application.Features.MovementImageUploadMappings.Constants;
using Application.Features.MovementImageUploadMappings.Models;
using Application.Features.MovementImageUploadMappings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using Domain.MappingEntities;
using MediatR;

namespace Application.Features.MovementImageUploadMappings.Queries.GetMovementImageUploadMappingList
{
    public class GetMovementImageUploadMappingListQuery : IRequest<MovementImageUploadMappingListModel>, ISecuredRequest
    {
        public PageRequest PageRequest { get; set; }

        public string[] Roles { get; } =
        {
            MovementImageUploadMappingRoles.MovementImageUploadMappingRead,
            MovementImageUploadMappingRoles.MovementImageUploadMappingAdmin
        };

        public class GetMovementImageUploadMappingListQueryHandler : IRequestHandler<GetMovementImageUploadMappingListQuery, MovementImageUploadMappingListModel>
        {
            private readonly IMovementImageUploadMappingRepository _movementImageUploadMappingRepository;
            private readonly IUserRepository _userRepository;
            private readonly IMovementRepository _movementRepository;
            private readonly MovementImageUploadMappingBusinessRules _movementImageUploadMappingBusinessRules;
            private readonly IMapper _mapper;

            public GetMovementImageUploadMappingListQueryHandler(IMovementImageUploadMappingRepository movementImageUploadMappingRepository, MovementImageUploadMappingBusinessRules movementImageUploadMappingBusinessRules, IMapper mapper, IUserRepository userRepository, IMovementRepository movementRepository)
            {
                _movementImageUploadMappingRepository = movementImageUploadMappingRepository;
                _movementImageUploadMappingBusinessRules = movementImageUploadMappingBusinessRules;
                _mapper = mapper;
                _userRepository = userRepository;
                _movementRepository = movementRepository;
            }

            public async Task<MovementImageUploadMappingListModel> Handle(GetMovementImageUploadMappingListQuery request, CancellationToken cancellationToken)
            {
                IPaginate<MovementImageUploadMapping> movementImageUploadMapping = await _movementImageUploadMappingRepository.GetListAsync(index: request.PageRequest.Page - 1, size: request.PageRequest.PageSize);

                MovementImageUploadMappingListModel mappedMovementImageUploadMappingListModel = _mapper.Map<MovementImageUploadMappingListModel>(movementImageUploadMapping);

                foreach (var item in mappedMovementImageUploadMappingListModel.Items)
                {
                    item.MovementId = item.MovementId;
                    item.MovementName = (await _movementRepository.GetAsync(x => x.Id == item.MovementId)).Name;
                    item.ImageUploadId = item.ImageUploadId;
                    item.Id = item.Id;
                }

                return mappedMovementImageUploadMappingListModel;
            }
        }
    }
}
