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

namespace Application.Features.DeleteStudents.Queries.GetDeleteStudentList
{
    public class GetDeleteStudentListQuery : IRequest<DeleteStudentListModel>, ISecuredRequest
    {
        public PageRequest PageRequest { get; set; }
        public string? SearchFirstName { get; set; }
        public string? SearchLastName { get; set; }
        public string[] Roles { get; } =
        {
            GeneralRoles.SystemAdmin,
            GeneralRoles.GymAdmin,
            GeneralRoles.PersonalTrainer
        };

        public class GetDeleteStudentListQueryHandler : IRequestHandler<GetDeleteStudentListQuery, DeleteStudentListModel>
        {
            private readonly IHttpContextAccessor _httpContextAccessor;
            private readonly IHelperService _helperService;
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;

            public GetDeleteStudentListQueryHandler(IUserRepository userRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor, IHelperService helperService)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _httpContextAccessor = httpContextAccessor;
                _helperService = helperService;
            }

            public async Task<DeleteStudentListModel> Handle(GetDeleteStudentListQuery request, CancellationToken cancellationToken)
            {
                var currentCustomer = await _helperService.CurrentCustomer();
                IPaginate<User> users = await _userRepository.GetListAsync(searchTerm: request.SearchFirstName != null ? u => u.FirstName.Contains(request.SearchFirstName) : null,
                    searchTerm2: request.SearchLastName != null ? u => u.LastName.Contains(request.SearchLastName) : null,
                    predicate: x => x.Type == 3 && x.CustomerId == currentCustomer && x.Status == false,
                    index: request.PageRequest.Page - 1, size: request.PageRequest.PageSize);
                DeleteStudentListModel mappedDeleteStudentListModel = _mapper.Map<DeleteStudentListModel>(users);

                return mappedDeleteStudentListModel;
            }
        }
    }
}
