using Application.Constants;
using Application.Features.Categories.Constants;
using Application.Features.Categories.Dtos;
using Application.Features.Categories.Rules;
using Application.Helpers;
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

namespace Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<CreateCategoryDto>,ISecuredRequest
    {
        public string Name { get; set; }
        public int CompanyId { get; set; }
        public string[] Roles { get; } =
        {
            GeneralRoles.SystemAdmin,
        };

        public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryDto>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IHelperService _helperService;
            private readonly CategoryBusinessRules _categoryBusinessRules;
            private readonly IMapper _mapper;

            public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, CategoryBusinessRules categoryBusinessRules, IMapper mapper, IHelperService helperService)
            {
                _categoryRepository = categoryRepository;
                _categoryBusinessRules = categoryBusinessRules;
                _mapper = mapper;
                _helperService = helperService;
            }

            public async Task<CreateCategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
            {
                Category? mappedCategory = _mapper.Map<Category>(request);

                mappedCategory.CompanyId = await _helperService.CurrentCompany();

                Category createCategory = await _categoryRepository.AddAsync(mappedCategory);

                CreateCategoryDto createCategoryDto = _mapper.Map<CreateCategoryDto>(createCategory);

                return createCategoryDto;
            }
        }
    }
}
