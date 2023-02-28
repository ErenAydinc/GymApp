using Application.Constants;
using Application.Features.Customers.Models;
using Application.Features.Customers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.Customers.Queries.GetCustomerList
{
    public class GetCustomerListQuery:IRequest<CustomerListModel>,ISecuredRequest
    {
        public PageRequest PageRequest { get; set; }
        public string[] Roles { get; } =
        {
            GeneralRoles.SystemAdmin,
        };
        public class GetCustomerListQueryHandler : IRequestHandler<GetCustomerListQuery, CustomerListModel>
        {
            private readonly ICustomerRepository _customerRepository;
            private readonly IUserRepository _userRepository;
            private readonly CustomerBusinessRules _customerBusinessRules;
            private readonly IMapper _mapper;

            public GetCustomerListQueryHandler(ICustomerRepository customerRepository, CustomerBusinessRules customerBusinessRules, IMapper mapper, IUserRepository userRepository)
            {
                _customerRepository = customerRepository;
                _customerBusinessRules = customerBusinessRules;
                _mapper = mapper;
                _userRepository = userRepository;
            }

            public async Task<CustomerListModel> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Customer> customer = await _customerRepository.GetListAsync(index: request.PageRequest.Page -1, size: request.PageRequest.PageSize);
                CustomerListModel mappedCustomerListModel = _mapper.Map<CustomerListModel>(customer);
                return mappedCustomerListModel;
            }
        }
    }
}
