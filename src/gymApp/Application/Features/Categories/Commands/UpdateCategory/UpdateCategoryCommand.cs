using Application.Constants;
using Application.Features.Categories.Constants;
using Application.Features.Categories.Dtos;
using Application.Features.Categories.Rules;
using Application.Helpers;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<UpdateCategoryDto>, ISecuredRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }

        public string[] Roles { get; } =
        {
            GeneralRoles.SystemAdmin,
        };

        public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, UpdateCategoryDto>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly CategoryBusinessRules _categoryBusinessRules;
            private readonly IHelperService _helperService;
            private readonly IMapper _mapper;

            public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, CategoryBusinessRules categoryBusinessRules, IMapper mapper, IHelperService helperService)
            {
                _categoryRepository = categoryRepository;
                _categoryBusinessRules = categoryBusinessRules;
                _mapper = mapper;
                _helperService = helperService;
            }

            public async Task<UpdateCategoryDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
            {
                await _categoryBusinessRules.CategoryNotAlreadyExists(request.Id);
                await _categoryBusinessRules.CategoryAlreadyExists(request.Id);

                Category? mappedCategory = _mapper.Map<Category>(request);

                mappedCategory.CompanyId = await _helperService.CurrentCompany();

                Category updateCategory = await _categoryRepository.UpdateAsync(mappedCategory);

                UpdateCategoryDto updateCategoryDto = _mapper.Map<UpdateCategoryDto>(updateCategory);

                return updateCategoryDto;
            }
        }
    }
}
