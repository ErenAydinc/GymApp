using Application.Features.Commons.Models;
using Application.Helpers;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.Commons.Queries.GetCommonStudentList
{
    public class GetCommonStudentListQuery:IRequest<CommonStudentListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetCommonStudentListQueryHandler : IRequestHandler<GetCommonStudentListQuery, CommonStudentListModel>
        {
            private readonly IUserRepository _userRepository;
            private readonly IHelperService _helperService;
            private readonly IMapper _mapper;

            public GetCommonStudentListQueryHandler(IUserRepository userRepository, IMapper mapper, IHelperService helperService)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _helperService = helperService;
            }

            public async Task<CommonStudentListModel> Handle(GetCommonStudentListQuery request, CancellationToken cancellationToken)
            {
                int currentCustomerId = await _helperService.CurrentCustomer();
                IPaginate<User> students = await _userRepository.GetListAsync(predicate:x=>x.CustomerId==currentCustomerId && x.Type==3,index: request.PageRequest.Page -1, size: request.PageRequest.PageSize);
                CommonStudentListModel mappedCommonStudentListModel = _mapper.Map<CommonStudentListModel>(students);
                foreach (var commonStudentList in mappedCommonStudentListModel.Items)
                {
                    commonStudentList.Name = await _helperService.FullName(commonStudentList.Id);
                    commonStudentList.Id = commonStudentList.Id;
                }
                return mappedCommonStudentListModel;
            }
        }
    }
}
