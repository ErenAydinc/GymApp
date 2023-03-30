using Application.Features.Commons.Models;
using Application.Features.UsersMovements.Models;
using Application.Helpers;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commons.Queries.GetCommonUserMovementList
{
    public class GetCommonUserMovementListQuery: IRequest<CommonUserMovementListModel>
    {
        public int SelectedDay { get; set; }
        public PageRequest PageRequest { get; set; }

        public class GetCommonUserMovementListQueryHandler : IRequestHandler<GetCommonUserMovementListQuery, CommonUserMovementListModel>
        {
            private readonly IUsersMovementRepository _usersMovementRepository;
            private readonly IMovementRepository _movementRepository;
            private readonly IHelperService _helperService;
            private readonly IUserRepository _userRepository;
            private readonly IMovementImageRepository _movementImageRepository;
            private readonly IMapper _mapper;

            public GetCommonUserMovementListQueryHandler(IUsersMovementRepository usersMovementRepository, IMovementRepository movementRepository, IHelperService helperService, IUserRepository userRepository, IMovementImageRepository movementImageRepository, IMapper mapper)
            {
                _usersMovementRepository = usersMovementRepository;
                _movementRepository = movementRepository;
                _helperService = helperService;
                _userRepository = userRepository;
                _movementImageRepository = movementImageRepository;
                _mapper = mapper;
            }

            public async Task<CommonUserMovementListModel> Handle(GetCommonUserMovementListQuery request, CancellationToken cancellationToken)
            {
                int? userId = await _helperService.CurrentUser();

                IPaginate<UsersMovement> usersMovement = await _usersMovementRepository.GetListAsync(predicate: x => x.UserId == userId && (request.SelectedDay == 1 ? x.IsMonday == true : request.SelectedDay == 2 ? x.IsTuesday == true : request.SelectedDay == 3 ? x.IsWednesday == true : request.SelectedDay == 4 ?
                x.IsThursday == true : request.SelectedDay == 5 ? x.IsFriday == true : request.SelectedDay == 6 ? x.IsSaturday == true : request.SelectedDay == 7 ? x.IsSunday == true : false), index:0, size: int.MaxValue);

                CommonUserMovementListModel commonUserMovementListModel = _mapper.Map<CommonUserMovementListModel>(usersMovement);

                foreach (var userMovement in commonUserMovementListModel.Items.ToList())
                {
                    var movement = await _movementRepository.GetAsync(x => x.Id == userMovement.MovementId);
                    userMovement.MovementName = movement.Name;
                    userMovement.UserName = await _helperService.FullName(userMovement.UserId);
                    IList<MovementImage> movementImages = await _movementImageRepository.GetAllAsync(x => x.MovementId == userMovement.MovementId);
                    userMovement.MovementImage = movementImages;
                    userMovement.Description = movement.Description;

                }

                return commonUserMovementListModel;
            }
        }
    }
}
