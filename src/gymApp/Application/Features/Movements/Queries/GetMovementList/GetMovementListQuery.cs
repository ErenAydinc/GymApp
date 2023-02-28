using Application.Constants;
using Application.Features.Movements.Constants;
using Application.Features.Movements.Dtos;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Movements.Queries.GetMovementList
{
    public class GetMovementListQuery:IRequest<MovementListModel>,ISecuredRequest
    {
        public PageRequest PageRequest { get; set; }
        public string? SearchMovementName { get; set; }
        public int CategoryId { get; set; }
        public string[] Roles { get; } =
        {
            GeneralRoles.SystemAdmin,
            GeneralRoles.GymAdmin,
            GeneralRoles.PersonalTrainer
        };
        public class GetMovementListQueryHandler : IRequestHandler<GetMovementListQuery, MovementListModel>
        {
            private readonly IMovementRepository _movementRepository;
            
            private readonly MovementBusinessRules _movementBusinessRules;
            private readonly IMovementImageRepository _movementImageRepository;
            private readonly ICategoryRepository _categoryRepository;
            private readonly IHelperService _helperService;
            private readonly IMapper _mapper;

            public GetMovementListQueryHandler(IMovementRepository movementRepository, MovementBusinessRules movementBusinessRules, IMapper mapper, IMovementImageRepository movementImageRepository, IHelperService helperService, ICategoryRepository categoryRepository)
            {
                _movementRepository = movementRepository;
                _movementBusinessRules = movementBusinessRules;
                _mapper = mapper;
                _movementImageRepository = movementImageRepository;
                _helperService = helperService;
                _categoryRepository = categoryRepository;
            }

            public async Task<MovementListModel> Handle(GetMovementListQuery request, CancellationToken cancellationToken)
            {
                var currentCustomer = await _helperService.CurrentCustomer();
                IPaginate<Movement> movement = await _movementRepository.GetListAsync(predicate: request.CategoryId > 0 ? x => x.CategoryId == request.CategoryId : null,
                    searchTerm: request.SearchMovementName != null ? x => x.Name.Contains(request.SearchMovementName) : null,
                    index: request.PageRequest.Page -1, size: request.PageRequest.PageSize);
                MovementListModel mappedMovementListModel = _mapper.Map<MovementListModel>(movement);

                
                foreach (var item in mappedMovementListModel.Items)
                {
                    item.Id = item.Id;
                    item.Name = item.Name;
                    item.Description = item.Description;
                    item.CategoryId = item.CategoryId;
                    var movementImagebyMovementId = await _movementImageRepository.GetAllAsync(x => x.MovementId == item.Id);
                    foreach (var movementImage in movementImagebyMovementId)
                    {
                        item.MovementImage = movementImagebyMovementId;
                    }
                }
                return mappedMovementListModel;
            }
        }
    }
}
