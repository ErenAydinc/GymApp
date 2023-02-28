using Application.Features.Categories.Constants;
using Application.Features.Categories.Models;
using Application.Features.Categories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Queries.GetCategoryList
{
    public class GetCategoryListQuery:IRequest<CategoryListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetCategoryListQueryHandler : IRequestHandler<GetCategoryListQuery, CategoryListModel>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly CategoryBusinessRules _categoryBusinessRules;
            private readonly IMapper _mapper;

            public GetCategoryListQueryHandler(ICategoryRepository categoryRepository, CategoryBusinessRules categoryBusinessRules, IMapper mapper)
            {
                _categoryRepository = categoryRepository;
                _categoryBusinessRules = categoryBusinessRules;
                _mapper = mapper;
            }

            public async Task<CategoryListModel> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Category> category = await _categoryRepository.GetListAsync(index: request.PageRequest.Page -1, size: request.PageRequest.PageSize);
                CategoryListModel mappedCategoryListModel = _mapper.Map<CategoryListModel>(category);
                return mappedCategoryListModel;
            }
        }
    }
}
