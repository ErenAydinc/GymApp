using Application.Constants;
using Application.Features.Customers.Constants;
using Application.Features.Customers.Dtos;
using Application.Features.Customers.Rules;
using Application.Helpers;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand:IRequest<UpdateCustomerDto>,ISecuredRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? CompanyId { get; set; }
        public string[] Roles { get; } =
        {
            GeneralRoles.SystemAdmin,
        };

        public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, UpdateCustomerDto>
        {
            private readonly ICustomerRepository _customerRepository;
            private readonly CustomerBusinessRules _customerBusinessRules;
            private readonly IHelperService _helperService;
            private readonly IMapper _mapper;

            public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, CustomerBusinessRules customerBusinessRules, IMapper mapper, IHelperService helperService)
            {
                _customerRepository = customerRepository;
                _customerBusinessRules = customerBusinessRules;
                _mapper = mapper;
                _helperService = helperService;
            }

            public async Task<UpdateCustomerDto> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
            {
                await _customerBusinessRules.CustomerNotAlreadyExists(request.Id);
                
                Customer? mappedCustomer = _mapper.Map<Customer>(request);

                mappedCustomer.CompanyId = await _helperService.CurrentCompany();

                Customer updateCustomer = await _customerRepository.UpdateAsync(mappedCustomer);

                UpdateCustomerDto updateCustomerDto =_mapper.Map<UpdateCustomerDto>(updateCustomer);

                return updateCustomerDto;
            }
        }
    }
}
