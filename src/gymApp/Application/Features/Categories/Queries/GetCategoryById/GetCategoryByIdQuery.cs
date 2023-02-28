using Application.Features.Categories.Constants;
using Application.Features.Categories.Dtos;
using Application.Features.Categories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdQuery:IRequest<GetCategoryByIdDto>
    {
        public int Id { get; set; }
        public class GetCategoryByIdQueryHandler:IRequestHandler<GetCategoryByIdQuery, GetCategoryByIdDto>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly CategoryBusinessRules _categoryBusinessRules;
            private readonly IMapper _mapper;

            public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository, CategoryBusinessRules categoryBusinessRules, IMapper mapper)
            {
                _categoryRepository = categoryRepository;
                _categoryBusinessRules = categoryBusinessRules;
                _mapper = mapper;
            }

            public async Task<GetCategoryByIdDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
            {
                await _categoryBusinessRules.CategoryNotAlreadyExists(request.Id);

                Category? category= await _categoryRepository.GetAsync(x => x.Id == request.Id);

                GetCategoryByIdDto getCategoryByIdDto = _mapper.Map<GetCategoryByIdDto>(category);

                return getCategoryByIdDto;
            }
        }
    }
}
