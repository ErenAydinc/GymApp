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

namespace Application.Features.PersonalTrainers.Queries.GetPersonalTrainerList
{
    public class GetPersonalTrainerListQuery : IRequest<PersonalTrainerListModel>, ISecuredRequest
    {
        public PageRequest PageRequest { get; set; }
        public string SearchFirstName { get; set; }
        public string SearchLastName { get; set; }
        public string[] Roles { get; } =
        {
            GeneralRoles.SystemAdmin,
            GeneralRoles.GymAdmin,
            GeneralRoles.PersonalTrainer
        };

        public class GetPersonalTrainerListQueryHandler : IRequestHandler<GetPersonalTrainerListQuery, PersonalTrainerListModel>
        {
            private readonly IHttpContextAccessor _httpContextAccessor;
            private readonly IUserRepository _userRepository;
            private readonly IHelperService _helperService;
            private readonly IMapper _mapper;

            public GetPersonalTrainerListQueryHandler(IUserRepository userRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor, IHelperService helperService)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _httpContextAccessor = httpContextAccessor;
                _helperService = helperService;
            }

            public async Task<PersonalTrainerListModel> Handle(GetPersonalTrainerListQuery request, CancellationToken cancellationToken)
            {
                var currentCustomer = await _helperService.CurrentCustomer();
                IPaginate<User> users = await _userRepository.GetListAsync(predicate: x => x.Type == 2 && x.CustomerId == currentCustomer,
                    searchTerm: request.SearchFirstName != "null" ? x => x.FirstName.Contains(request.SearchFirstName) : null,
                    searchTerm2: request.SearchLastName != "null" ? x => x.LastName.Contains(request.SearchLastName) : null,
                    index: request.PageRequest.Page - 1, size: request.PageRequest.PageSize);
                PersonalTrainerListModel mappedPersonalTrainerListModel = _mapper.Map<PersonalTrainerListModel>(users);
                return mappedPersonalTrainerListModel;
            }
        }
    }
}
