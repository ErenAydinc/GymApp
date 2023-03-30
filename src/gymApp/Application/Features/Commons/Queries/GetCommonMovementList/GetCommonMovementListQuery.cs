using Application.Features.Commons.Models;
using Application.Helpers;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commons.Queries.GetCommonMovementList
{
    public class GetCommonMovementListQuery:IRequest<CommonMovementListModel>
    {
        public string? SearchMovementName { get; set; }
        public PageRequest PageRequest { get; set; }
        public class GetCommonMovementListQueryHandler : IRequestHandler<GetCommonMovementListQuery, CommonMovementListModel>
        {
            private readonly IMovementRepository _movementRepository;
            private readonly IHelperService _helperService;
            private readonly IMapper _mapper;

            public GetCommonMovementListQueryHandler(IMapper mapper, IHelperService helperService, IMovementRepository movementRepository)
            {
                _mapper = mapper;
                _helperService = helperService;
                _movementRepository = movementRepository;
            }

            public async Task<CommonMovementListModel> Handle(GetCommonMovementListQuery request, CancellationToken cancellationToken)
            {
                int currentCustomerId = await _helperService.CurrentCustomer();
                IPaginate<Movement> movements = await _movementRepository.GetListAsync(searchTerm: request.SearchMovementName != "null" ? x => x.Name.Contains(request.SearchMovementName) : null, index:request.PageRequest.Page-1,size:request.PageRequest.PageSize);
                CommonMovementListModel mappedCommonMovementListModel = _mapper.Map<CommonMovementListModel>(movements);
                foreach (var commonMovementList in mappedCommonMovementListModel.Items)
                {
                    commonMovementList.Name= commonMovementList.Name;
                    commonMovementList.Id = commonMovementList.Id;
                }
                return mappedCommonMovementListModel;
            }
        }
    }
}
