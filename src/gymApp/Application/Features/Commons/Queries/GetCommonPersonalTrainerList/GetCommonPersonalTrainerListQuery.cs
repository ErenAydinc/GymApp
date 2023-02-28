using Application.Features.Commons.Models;
using Application.Helpers;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.Commons.Queries.GetCommonPersonalTrainerList
{
    public class GetCommonPersonalTrainerListQuery:IRequest<CommonPersonalTrainerListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetCommonPersonalTrainerListQueryHandler : IRequestHandler<GetCommonPersonalTrainerListQuery, CommonPersonalTrainerListModel>
        {
            private readonly IUserRepository _userRepository;
            private readonly IPersonalTrainerStudentRepository _personalTrainerStudentRepository;
            private readonly IHelperService _helperService;
            private readonly IMapper _mapper;

            public GetCommonPersonalTrainerListQueryHandler(IUserRepository userRepository, IMapper mapper, IHelperService helperService, IPersonalTrainerStudentRepository personalTrainerStudentRepository)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _helperService = helperService;
                _personalTrainerStudentRepository = personalTrainerStudentRepository;
            }

            public async Task<CommonPersonalTrainerListModel> Handle(GetCommonPersonalTrainerListQuery request, CancellationToken cancellationToken)
            {
                int currentCustomerId = await _helperService.CurrentCustomer();
                IPaginate<User> personalTrainers = await _userRepository.GetListAsync(predicate:x=>x.CustomerId==currentCustomerId && x.Type==2,index: request.PageRequest.Page -1, size: request.PageRequest.PageSize);
                CommonPersonalTrainerListModel mappedCommonPersonalTrainerListModel = _mapper.Map<CommonPersonalTrainerListModel>(personalTrainers);
                foreach (var commonPersonalTrainerList in mappedCommonPersonalTrainerListModel.Items)
                {
                    commonPersonalTrainerList.Name = await _helperService.FullName(commonPersonalTrainerList.Id);
                    commonPersonalTrainerList.Id = commonPersonalTrainerList.Id;
                    commonPersonalTrainerList.StudentCount = (await _personalTrainerStudentRepository.GetAllAsync(x=>x.PersonalTrainerId==commonPersonalTrainerList.Id)).Count;
                }
                return mappedCommonPersonalTrainerListModel;
            }
        }
    }
}
