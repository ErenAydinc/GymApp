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

namespace Application.Features.Commons.Queries.GetCommonStudentMovementListByStudentIdAndSelectedDay
{
    public class GetCommonStudentMovementListByStudentIdAndSelectedDayQuery: IRequest<CommonStudentMovementListByStudentIdAndSelectedDayModel>
    {
        public int SelectedDay { get; set; }
        public int StudentId { get; set; }
        public PageRequest PageRequest { get; set; }

        public class GetCommonStudentMovementListByStudentIdAndSelectedDayQueryHandler : IRequestHandler<GetCommonStudentMovementListByStudentIdAndSelectedDayQuery, CommonStudentMovementListByStudentIdAndSelectedDayModel>
        {
            private readonly IUsersMovementRepository _usersMovementRepository;
            private readonly IMovementRepository _movementRepository;
            private readonly IHelperService _helperService;
            private readonly IUserRepository _userRepository;
            private readonly IMovementImageRepository _movementImageRepository;
            private readonly IMapper _mapper;

            public GetCommonStudentMovementListByStudentIdAndSelectedDayQueryHandler(IUsersMovementRepository usersMovementRepository, IMovementRepository movementRepository, IHelperService helperService, IUserRepository userRepository, IMovementImageRepository movementImageRepository, IMapper mapper)
            {
                _usersMovementRepository = usersMovementRepository;
                _movementRepository = movementRepository;
                _helperService = helperService;
                _userRepository = userRepository;
                _movementImageRepository = movementImageRepository;
                _mapper = mapper;
            }

            public async Task<CommonStudentMovementListByStudentIdAndSelectedDayModel> Handle(GetCommonStudentMovementListByStudentIdAndSelectedDayQuery request, CancellationToken cancellationToken)
            {
                IPaginate<UsersMovement> usersMovement = await _usersMovementRepository.GetListAsync(predicate: x => x.UserId == request.StudentId && (request.SelectedDay == 1 ? x.IsMonday == true : request.SelectedDay == 2 ? x.IsTuesday == true : request.SelectedDay == 3 ? x.IsWednesday == true : request.SelectedDay == 4 ?
                x.IsThursday == true : request.SelectedDay == 5 ? x.IsFriday == true : request.SelectedDay == 6 ? x.IsSaturday == true : request.SelectedDay == 7 ? x.IsSunday == true : false), index:0, size: int.MaxValue);

                CommonStudentMovementListByStudentIdAndSelectedDayModel commonStudentMovementListByStudentIdAndSelectedDayModel = _mapper.Map<CommonStudentMovementListByStudentIdAndSelectedDayModel>(usersMovement);

                foreach (var userMovement in commonStudentMovementListByStudentIdAndSelectedDayModel.Items.ToList())
                {
                    userMovement.Id = userMovement.Id;
                    userMovement.MovementId = userMovement.MovementId;
                    userMovement.StudentId = userMovement.StudentId;
                    userMovement.MovementName = (await _movementRepository.GetAsync(x => x.Id == userMovement.MovementId)).Name;
                    userMovement.SetNumber = userMovement.SetNumber;
                    userMovement.RepetitionNumber = userMovement.RepetitionNumber;
                    userMovement.Weight = userMovement.Weight;

                }

                return commonStudentMovementListByStudentIdAndSelectedDayModel;
            }
        }
    }
}
