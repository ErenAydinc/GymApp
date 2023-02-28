using Application.Features.Companies.Commands.CreateCompany;
using Application.Features.Companies.Commands.DeleteCompany;
using Application.Features.Companies.Commands.UpdateCompany;
using Application.Features.Companies.Dtos;
using Application.Features.Companies.Models;
using Application.Features.Companies.Queries.GetCompanyById;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;

namespace Application.Features.Companies.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Company, CreateCompanyDto>().ReverseMap();
            CreateMap<Company, CreateCompanyCommand>().ReverseMap();

            CreateMap<Company, UpdateCompanyDto>().ReverseMap();
            CreateMap<Company, UpdateCompanyCommand>().ReverseMap();

            CreateMap<Company, DeleteCompanyDto>().ReverseMap();
            CreateMap<Company, DeleteCompanyCommand>().ReverseMap();

            CreateMap<Company,GetCompanyByIdDto>().ReverseMap();
            CreateMap<Company, GetCompanyByIdQuery>().ReverseMap();

            CreateMap<IPaginate<Company>, CompanyListModel>().ReverseMap();
            CreateMap<Company, GetCompanyListDto>().ReverseMap();
        }
    }
}
