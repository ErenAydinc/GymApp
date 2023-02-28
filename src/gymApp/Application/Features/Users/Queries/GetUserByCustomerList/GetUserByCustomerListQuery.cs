using Application.Constants;
using Application.Features.Users.Constants;
using Application.Features.Users.Dtos;
using Application.Features.Users.Models;
using Application.Features.Users.Rules;
using Application.Helpers;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Queries.GetUserByCustomerList
{
    public class GetUserByCustomerListQuery:IRequest<UserByCustomerListModel>,ISecuredRequest
    {
        public PageRequest PageRequest { get; set; }

        public string[] Roles { get; } =
        {
            GeneralRoles.SystemAdmin,
            GeneralRoles.GymAdmin,
            GeneralRoles.PersonalTrainer
        };

        public class GetUserByCustomerListQueryHandler : IRequestHandler<GetUserByCustomerListQuery, UserByCustomerListModel>
        {
            private readonly IUserRepository _userRepository;
            private readonly IHelperService _helperService;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _userBusinessRules;
            public GetUserByCustomerListQueryHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules, IHelperService helperService)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
                _helperService = helperService;
            }

            public async Task<UserByCustomerListModel> Handle(GetUserByCustomerListQuery request, CancellationToken cancellationToken)
            {
                var customerId = await _helperService.CurrentCustomer();

                IPaginate<User?> user = await _userRepository.GetListAsync(predicate:x=>x.CustomerId== customerId,index:request.PageRequest.Page - 1,size:request.PageRequest.PageSize);

                UserByCustomerListModel userByCustomerListModel = _mapper.Map<UserByCustomerListModel>(user);

                return userByCustomerListModel;
            }
        }
    }
}
