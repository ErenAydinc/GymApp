using Application.Constants;
using Application.Features.UsersMovements.Constants;
using Application.Features.UsersMovements.Models;
using Application.Features.UsersMovements.Rules;
using Application.Helpers;
using Application.Services.AuthService;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Domain.Entities;
using Domain.MappingEntities;
using MediatR;

namespace Application.Features.UsersMovements.Queries.GetUsersMovementList
{
    public class GetUsersMovementListQuery : IRequest<UsersMovementListModel>,ISecuredRequest
    {
        public PageRequest PageRequest { get; set; }
        public string[] Roles { get; } =
        {
            GeneralRoles.SystemAdmin,
            GeneralRoles.GymAdmin,
            GeneralRoles.PersonalTrainer
        };


        public class GetUsersMovementListQueryHandler : IRequestHandler<GetUsersMovementListQuery, UsersMovementListModel>
        {
            private readonly IUsersMovementRepository _usersMovementRepository;
            private readonly IMovementRepository _movementRepository;
            private readonly IHelperService _helperService;
            private readonly IUserRepository _userRepository;
            private readonly IMovementImageRepository _movementImageRepository;
            private readonly UsersMovementBusinessRules _usersMovementBusinessRules;
            private readonly IMapper _mapper;

            public GetUsersMovementListQueryHandler(IUsersMovementRepository usersMovementRepository, UsersMovementBusinessRules usersMovementBusinessRules, IMapper mapper, IHelperService helperService, IMovementRepository movementRepository, IMovementImageRepository movementImageRepository, IUserRepository userRepository)
            {
                _usersMovementRepository = usersMovementRepository;
                _usersMovementBusinessRules = usersMovementBusinessRules;
                _mapper = mapper;
                _helperService = helperService;
                _movementRepository = movementRepository;
                _movementImageRepository = movementImageRepository;
                _userRepository = userRepository;
            }

            public async Task<UsersMovementListModel> Handle(GetUsersMovementListQuery request, CancellationToken cancellationToken)
            {
                IPaginate<UsersMovement> usersMovement = await _usersMovementRepository.GetListAsync(index: request.PageRequest.Page - 1, size: request.PageRequest.PageSize);

                UsersMovementListModel mappedUsersMovementListModel = _mapper.Map<UsersMovementListModel>(usersMovement);

                foreach (var userMovement in mappedUsersMovementListModel.Items.ToList())
                {
                    var currentCustomer = await _helperService.CurrentCustomer();
                    var currentCustomerUser = await _userRepository.GetAsync(x => x.CustomerId == currentCustomer && x.Id == userMovement.UserId);

                    userMovement.MovementId = userMovement.MovementId;
                    userMovement.UserId = userMovement.UserId;
                    userMovement.MovementName = ((await _movementRepository.GetAsync(x => x.Id == userMovement.MovementId)).Name);
                    userMovement.UserName = await _helperService.FullName(userMovement.UserId);
                    IList<MovementImage> movementImages = await _movementImageRepository.GetAllAsync(x => x.MovementId == userMovement.MovementId);
                    userMovement.MovementImage = movementImages;

                    if (currentCustomerUser == null)
                    {
                        mappedUsersMovementListModel.Count--;
                        mappedUsersMovementListModel.Items.Remove(userMovement);
                    }

                }

                return mappedUsersMovementListModel;
            }
        }
    }
}
