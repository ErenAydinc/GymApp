using Application.Constants;
using Application.Features.Customers.Dtos;
using Application.Features.Customers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.Customers.Queries.GetCustomerById
{
    public class GetCustomerByIdQuery:IRequest<GetCustomerByIdDto>,ISecuredRequest
    {
        public int Id { get; set; }
        public string[] Roles { get; } =
        {
            GeneralRoles.SystemAdmin,
        };
        public class GetCustomerByIdQueryHandler:IRequestHandler<GetCustomerByIdQuery, GetCustomerByIdDto>
        {
            private readonly ICustomerRepository _customerRepository;
            private readonly CustomerBusinessRules _customerBusinessRules;
            private readonly IMapper _mapper;

            public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository, CustomerBusinessRules customerBusinessRules, IMapper mapper)
            {
                _customerRepository = customerRepository;
                _customerBusinessRules = customerBusinessRules;
                _mapper = mapper;
            }

            public async Task<GetCustomerByIdDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
            {
                await _customerBusinessRules.CustomerNotAlreadyExists(request.Id);

                Customer? customer= await _customerRepository.GetAsync(x => x.Id == request.Id);

                GetCustomerByIdDto getCustomerByIdDto = _mapper.Map<GetCustomerByIdDto>(customer);

                return getCustomerByIdDto;
            }
        }
    }
}
