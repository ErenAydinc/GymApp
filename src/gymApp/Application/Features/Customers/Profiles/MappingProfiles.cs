﻿using Application.Features.Customers.Commands.CreateCustomer;
using Application.Features.Customers.Commands.DeleteCustomer;
using Application.Features.Customers.Commands.UpdateCustomer;
using Application.Features.Customers.Dtos;
using Application.Features.Customers.Models;
using Application.Features.Customers.Queries.GetCustomerById;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;

namespace Application.Features.Customers.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Customer, CreateCustomerDto>().ReverseMap();
            CreateMap<Customer, CreateCustomerCommand>().ReverseMap();

            CreateMap<Customer, UpdateCustomerDto>().ReverseMap();
            CreateMap<Customer, UpdateCustomerCommand>().ReverseMap();

            CreateMap<Customer, DeleteCustomerDto>().ReverseMap();
            CreateMap<Customer, DeleteCustomerCommand>().ReverseMap();

            CreateMap<Customer,GetCustomerByIdDto>().ReverseMap();
            CreateMap<Customer, GetCustomerByIdQuery>().ReverseMap();

            CreateMap<IPaginate<Customer>, CustomerListModel>().ReverseMap();
            CreateMap<Customer, GetCustomerListDto>().ReverseMap();
        }
    }
}
