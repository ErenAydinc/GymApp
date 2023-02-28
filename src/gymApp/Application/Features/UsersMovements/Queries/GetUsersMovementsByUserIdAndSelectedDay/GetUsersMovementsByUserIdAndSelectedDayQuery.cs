using Application.Constants;
using Application.Features.UsersMovements.Constants;
using Application.Features.UsersMovements.Models;
using Application.Features.UsersMovements.Rules;
using Application.Helpers;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.UsersMovements.Queries.GetUsersMovementsByUserIdAndSelectedDay
{
    public class GetUsersMovementsByUserIdAndSelectedDayQuery : IRequest<UsersMovementsListByUserIdAndSelectedDayModel>,ISecuredRequest
    {
        public int UserId { get; set; }
        public int SelectedDay { get; set; }
        public PageRequest PageRequest { get; set; }
        public string[] Roles { get; } =
        {
            GeneralRoles.SystemAdmin,
            GeneralRoles.GymAdmin,
            GeneralRoles.PersonalTrainer
        };

        public class GetUsersMovementsByUserIdAndSelectedDayQueryHandler : IRequestHandler<GetUsersMovementsByUserIdAndSelectedDayQuery, UsersMovementsListByUserIdAndSelectedDayModel>
        {
            private readonly IUsersMovementRepository _usersMovementRepository;
            private readonly IMovementRepository _movementRepository;
            private readonly IHelperService _helperService;
            private readonly IUserRepository _userRepository;
            private readonly IMovementImageRepository _movementImageRepository;
            private readonly UsersMovementBusinessRules _usersMovementBusinessRules;
            private readonly IMapper _mapper;

            public GetUsersMovementsByUserIdAndSelectedDayQueryHandler(IUsersMovementRepository usersMovementRepository, UsersMovementBusinessRules usersMovementBusinessRules, IMapper mapper, IHelperService helperService, IMovementRepository movementRepository, IMovementImageRepository movementImageRepository, IUserRepository userRepository)
            {
                _usersMovementRepository = usersMovementRepository;
                _usersMovementBusinessRules = usersMovementBusinessRules;
                _mapper = mapper;
                _helperService = helperService;
                _movementRepository = movementRepository;
                _movementImageRepository = movementImageRepository;
                _userRepository = userRepository;
            }

            public async Task<UsersMovementsListByUserIdAndSelectedDayModel> Handle(GetUsersMovementsByUserIdAndSelectedDayQuery request, CancellationToken cancellationToken)
            {

                IPaginate<UsersMovement> usersMovement = await _usersMovementRepository.GetListAsync(predicate:x=>x.UserId==request.UserId && (request.SelectedDay == 1 ? x.IsMonday == true : request.SelectedDay == 2 ? x.IsTuesday == true : request.SelectedDay == 3 ? x.IsWednesday == true : request.SelectedDay == 4 ?
                x.IsThursday == true : request.SelectedDay == 5 ? x.IsFriday == true : request.SelectedDay == 6 ? x.IsSaturday == true : request.SelectedDay == 7 ? x.IsSunday == true : false), index: request.PageRequest.Page - 1, size: request.PageRequest.PageSize);

                UsersMovementsListByUserIdAndSelectedDayModel mappedUsersMovementsListByUserIdAndSelectedDayModel = _mapper.Map<UsersMovementsListByUserIdAndSelectedDayModel>(usersMovement);

                foreach (var userMovement in mappedUsersMovementsListByUserIdAndSelectedDayModel.Items.ToList())
                {
                    userMovement.MovementId = userMovement.MovementId;
                    userMovement.UserId = userMovement.UserId;
                    userMovement.MovementName = ((await _movementRepository.GetAsync(x => x.Id == userMovement.MovementId)).Name);
                    userMovement.UserName = await _helperService.FullName(userMovement.UserId);
                    IList<MovementImage> movementImages = await _movementImageRepository.GetAllAsync(x => x.MovementId == userMovement.MovementId);
                    userMovement.MovementImage = movementImages;
                    userMovement.SetNumber = userMovement.SetNumber;
                    userMovement.RepetitionNumber = userMovement.RepetitionNumber;

                }

                return mappedUsersMovementsListByUserIdAndSelectedDayModel;
            }
        }
    }
}
