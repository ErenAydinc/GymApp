using Application.Constants;
using Application.Features.Users.Constants;
using Application.Features.Users.Models;
using Application.Helpers;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Users.Queries.GetUserList
{
    public class GetUserListQuery : IRequest<UserListModel>,ISecuredRequest
    {
        public PageRequest PageRequest { get; set; }
        public string[] Roles { get; } =
        {
            GeneralRoles.SystemAdmin,
        };

        public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, UserListModel>
        {
            private readonly IHttpContextAccessor _httpContextAccessor;
            private readonly IUserRepository _userRepository;
            private readonly IHelperService _helperService;
            private readonly IMapper _mapper;

            public GetUserListQueryHandler(IUserRepository userRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor, IHelperService helperService)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _httpContextAccessor = httpContextAccessor;
                _helperService = helperService;
            }

            public async Task<UserListModel> Handle(GetUserListQuery request, CancellationToken cancellationToken)
            {
                var currentCustomer = await _helperService.CurrentCustomer();
                IPaginate<User> users = await _userRepository.GetListAsync(index: request.PageRequest.Page - 1, size: request.PageRequest.PageSize);
                UserListModel mappedUserListModel = _mapper.Map<UserListModel>(users);

                return mappedUserListModel;
            }
        }
    }
}
