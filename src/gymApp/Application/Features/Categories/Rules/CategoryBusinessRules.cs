using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Rules
{
    public class CategoryBusinessRules
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryBusinessRules(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task CategoryAlreadyExists(int id)
        {
            Category? category = await _categoryRepository.GetAsync(x => x.Id == id);

            if (category != null) throw new BusinessException("Category already exists");
        }

        public async Task CategoryNotAlreadyExists(int id)
        {
            Category? category = await _categoryRepository.GetAsync(x => x.Id == id);

            if (category == null) throw new BusinessException("Category not already exists");
        }
    }
}
