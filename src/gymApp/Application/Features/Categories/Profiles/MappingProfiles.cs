using Application.Features.Categories.Commands.CreateCategory;
using Application.Features.Categories.Commands.DeleteCategory;
using Application.Features.Categories.Commands.UpdateCategory;
using Application.Features.Categories.Dtos;
using Application.Features.Categories.Models;
using Application.Features.Categories.Queries.GetCategoryById;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Categories.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryCommand>().ReverseMap();

            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryCommand>().ReverseMap();

            CreateMap<Category, DeleteCategoryDto>().ReverseMap();
            CreateMap<Category, DeleteCategoryCommand>().ReverseMap();

            CreateMap<Category,GetCategoryByIdDto>().ReverseMap();
            CreateMap<Category, GetCategoryByIdQuery>().ReverseMap();

            CreateMap<IPaginate<Category>, CategoryListModel>().ReverseMap();
            CreateMap<Category, GetCategoryListDto>().ReverseMap();
        }
    }
}
