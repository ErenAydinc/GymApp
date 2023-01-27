using Application.Features.Users.Dtos;
using Application.Features.Users.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Queries.GetUserList
{
    public class GetUserListQuery:IRequest<UserListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, UserListModel>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;

            public GetUserListQueryHandler(IUserRepository userRepository, IMapper mapper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
            }

            public async Task<UserListModel> Handle(GetUserListQuery request, CancellationToken cancellationToken)
            {
                IPaginate<User> users = await _userRepository.GetListAsync(index: request.PageRequest.Page-1, size: request.PageRequest.PageSize);
                UserListModel mappedUserListModel = _mapper.Map<UserListModel>(users);

                return mappedUserListModel;
            }
        }
    }
}
