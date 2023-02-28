using Application.Constants;
using Application.Features.Categories.Constants;
using Application.Features.Categories.Dtos;
using Application.Features.Categories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommand:IRequest<DeleteCategoryDto>,ISecuredRequest
    {
        public int Id { get; set; }

        public string[] Roles { get; } =
        {
            GeneralRoles.SystemAdmin,
        };

        public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, DeleteCategoryDto>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;
            private readonly CategoryBusinessRules _categoryBusinessRules;
            public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, CategoryBusinessRules categoryBusinessRules, IMapper mapper)
            {
                _categoryRepository = categoryRepository;
                _categoryBusinessRules = categoryBusinessRules;
                _mapper = mapper;
            }

            public async Task<DeleteCategoryDto> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
            {
                await _categoryBusinessRules.CategoryNotAlreadyExists(request.Id);
                
                Category? mappedCategory = _mapper.Map<Category>(request);

                Category deleteCategory = await _categoryRepository.DeleteAsync(mappedCategory);

                DeleteCategoryDto deleteCategoryDto =_mapper.Map<DeleteCategoryDto>(deleteCategory);

                return deleteCategoryDto;
            }
        }
    }
}
