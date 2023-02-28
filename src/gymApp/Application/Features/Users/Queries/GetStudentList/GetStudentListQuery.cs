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

namespace Application.Features.Students.Queries.GetStudentList
{
    public class GetStudentListQuery : IRequest<StudentListModel>, ISecuredRequest
    {
        public string? SearchFirstName { get; set; }
        public string? SearchLastName { get; set; }
        public bool Status { get; set; }
        public PageRequest PageRequest { get; set; }
        public string[] Roles { get; } =
        {
            GeneralRoles.SystemAdmin,
            GeneralRoles.GymAdmin,
            GeneralRoles.PersonalTrainer
        };

        public class GetStudentListQueryHandler : IRequestHandler<GetStudentListQuery, StudentListModel>
        {
            private readonly IHttpContextAccessor _httpContextAccessor;
            private readonly IHelperService _helperService;
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;

            public GetStudentListQueryHandler(IUserRepository userRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor, IHelperService helperService)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _httpContextAccessor = httpContextAccessor;
                _helperService = helperService;
            }

            public async Task<StudentListModel> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
            {
                var currentCustomer = await _helperService.CurrentCustomer();
                IList<User> deleteUsers = await _userRepository.GetAllAsync(x => x.CustomerId == currentCustomer && x.MemberEndDate <= DateTime.UtcNow && x.Status == true && x.Type == 3);
                foreach (var deleteUser in deleteUsers)
                {
                    User user = new()
                    {
                        Id = deleteUser.Id,
                        FirstName = deleteUser.FirstName,
                        LastName = deleteUser.LastName,
                        Email = deleteUser.Email,
                        CustomerId = deleteUser.CustomerId,
                        CompanyId = deleteUser.CompanyId,
                        PasswordSalt = deleteUser.PasswordSalt,
                        PasswordHash = deleteUser.PasswordHash,
                        Type = deleteUser.Type,
                        TimeZone = deleteUser.TimeZone,
                        MemberStartDate = deleteUser.MemberStartDate,
                        MemberEndDate = deleteUser.MemberEndDate,
                        AuthenticatorType = deleteUser.AuthenticatorType,
                        Status = false,
                    };
                    await _userRepository.UpdateAsync(user);
                }
                IPaginate<User> users = await _userRepository.GetListAsync(searchTerm: request.SearchFirstName != "null" ? u => u.FirstName.Contains(request.SearchFirstName) : null,
                    searchTerm2: request.SearchLastName != "null" ? u => u.LastName.Contains(request.SearchLastName) : null,
                    predicate: x => x.Type == 3 && x.CustomerId == currentCustomer && x.Status == request.Status,
                    index: request.PageRequest.Page - 1, size: request.PageRequest.PageSize);
                StudentListModel mappedStudentListModel = _mapper.Map<StudentListModel>(users);

                return mappedStudentListModel;
            }
        }
    }
}
