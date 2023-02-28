using Application.Constants;
using Application.Features.Customers.Constants;
using Application.Features.Customers.Dtos;
using Application.Features.Customers.Rules;
using Application.Helpers;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<CreateCustomerDto>,ISecuredRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? CompanyId { get; set; }

        public string[] Roles { get; } =
        {
            GeneralRoles.SystemAdmin,
        };


        public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerDto>
        {
            private readonly ICustomerRepository _customerRepository;
            private readonly IHelperService _helperService;
            private readonly CustomerBusinessRules _customerBusinessRules;
            private readonly IMapper _mapper;

            public CreateCustomerCommandHandler(ICustomerRepository customerRepository, CustomerBusinessRules customerBusinessRules, IMapper mapper, IHelperService helperService)
            {
                _customerRepository = customerRepository;
                _customerBusinessRules = customerBusinessRules;
                _mapper = mapper;
                _helperService = helperService;
            }

            public async Task<CreateCustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
            {
                Customer mappedCustomer = _mapper.Map<Customer>(request);

                int currentCompany= await _helperService.CurrentCompany();

                mappedCustomer.CompanyId = currentCompany;

                Customer createCustomer = await _customerRepository.AddAsync(mappedCustomer);

                CreateCustomerDto createCustomerDto = _mapper.Map<CreateCustomerDto>(createCustomer);

                return createCustomerDto;
            }
        }
    }
}
