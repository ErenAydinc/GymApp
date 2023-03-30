using Application.Features.Commons.Models;
using Application.Helpers;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commons.Queries.GetCommonPersonalTrainerStudentList
{
    public class GetCommonPersonalTrainerStudentListQuery : IRequest<CommonPersonalTrainerStudentListModel>
    {
        public class GetCommonPersonalTrainerStudentListQueryHandler : IRequestHandler<GetCommonPersonalTrainerStudentListQuery, CommonPersonalTrainerStudentListModel>
        {
            private readonly IUserRepository _userRepository;
            private readonly IHelperService _helperService;
            private readonly IMapper _mapper;
            private readonly IPersonalTrainerStudentRepository _personalTrainerStudentRepository;
            public GetCommonPersonalTrainerStudentListQueryHandler(IUserRepository userRepository,
                IMapper mapper,
                IHelperService helperService,
                IPersonalTrainerStudentRepository personalTrainerStudentRepository)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _helperService = helperService;
                _personalTrainerStudentRepository = personalTrainerStudentRepository;
            }

            public async Task<CommonPersonalTrainerStudentListModel> Handle(GetCommonPersonalTrainerStudentListQuery request, CancellationToken cancellationToken)
            {
                int currentPersonalTrainer = await _helperService.CurrentUser();
                IPaginate<PersonalTrainerStudent> personalTrainerStudent =await _personalTrainerStudentRepository.GetListAsync(
                    predicate: x => x.PersonalTrainerId == currentPersonalTrainer,
                    index: 0, size: int.MaxValue);
                CommonPersonalTrainerStudentListModel mappedCommonPersonalTrainerStudentListModel = _mapper.Map<CommonPersonalTrainerStudentListModel>(personalTrainerStudent);
                foreach (var commonPersonalTrainerStudentList in mappedCommonPersonalTrainerStudentListModel.Items)
                {
                    User? user =await _userRepository.GetAsync(x => x.Id == commonPersonalTrainerStudentList.StudentId);
                    commonPersonalTrainerStudentList.StudentFirstName = user.FirstName;
                    commonPersonalTrainerStudentList.StudentLastName = user.LastName;
                    commonPersonalTrainerStudentList.StudentEmail = user.Email;
                }
                return mappedCommonPersonalTrainerStudentListModel;
            }
        }
    }
}
