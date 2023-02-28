using Application.Constants;
using Application.Features.Customers.Constants;
using Application.Features.Customers.Dtos;
using Application.Features.Customers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand:IRequest<DeleteCustomerDto>,ISecuredRequest
    {
        public int Id { get; set; }
        public string[] Roles { get; } =
        {
            GeneralRoles.SystemAdmin,
        };

        public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, DeleteCustomerDto>
        {
            private readonly ICustomerRepository _customerRepository;
            private readonly CustomerBusinessRules _customerBusinessRules;
            private readonly IMapper _mapper;

            public DeleteCustomerCommandHandler(ICustomerRepository customerRepository, CustomerBusinessRules customerBusinessRules, IMapper mapper)
            {
                _customerRepository = customerRepository;
                _customerBusinessRules = customerBusinessRules;
                _mapper = mapper;
            }

            public async Task<DeleteCustomerDto> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
            {
                await _customerBusinessRules.CustomerNotAlreadyExists(request.Id);
                
                Customer? mappedCustomer = _mapper.Map<Customer>(request);

                Customer deleteCustomer = await _customerRepository.DeleteAsync(mappedCustomer);

                DeleteCustomerDto deleteCustomerDto =_mapper.Map<DeleteCustomerDto>(deleteCustomer);

                return deleteCustomerDto;
            }
        }
    }
}
