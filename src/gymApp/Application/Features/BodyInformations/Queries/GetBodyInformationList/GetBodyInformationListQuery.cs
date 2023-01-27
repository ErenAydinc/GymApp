using Application.Features.BodyInformations.Dtos;
using Application.Features.BodyInformations.Models;
using Application.Features.BodyInformations.Rules;
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

namespace Application.Features.BodyInformations.Queries.GetBodyInformationList
{
    public class GetBodyInformationListQuery : IRequest<BodyInformationListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetBodyInformationListQueryHandler : IRequestHandler<GetBodyInformationListQuery, BodyInformationListModel>
        {
            private readonly IBodyInformationRepository _bodyInformationRepository;
            private readonly IUserRepository _userRepository;
            private readonly BodyInformationBusinessRules _bodyInformationBusinessRules;
            private readonly IMapper _mapper;

            public GetBodyInformationListQueryHandler(IBodyInformationRepository bodyInformationRepository, BodyInformationBusinessRules bodyInformationBusinessRules, IMapper mapper, IUserRepository userRepository)
            {
                _bodyInformationRepository = bodyInformationRepository;
                _bodyInformationBusinessRules = bodyInformationBusinessRules;
                _mapper = mapper;
                _userRepository = userRepository;
            }

            public async Task<BodyInformationListModel> Handle(GetBodyInformationListQuery request, CancellationToken cancellationToken)
            {
                IPaginate<BodyInformation> bodyInformation = await _bodyInformationRepository.GetListAsync(index: request.PageRequest.Page - 1, size: request.PageRequest.PageSize);
                BodyInformationListModel mappedBodyInformationListModel = _mapper.Map<BodyInformationListModel>(bodyInformation);
                foreach (var mbi in mappedBodyInformationListModel.Items)
                {
                    mbi.Shoulder = mbi.Shoulder;
                    mbi.Arm = mbi.Arm;
                    mbi.FirstName = (await _userRepository.GetAsync(x => x.Id == mbi.UserId)).FirstName;
                    mbi.LastName = (await _userRepository.GetAsync(x => x.Id == mbi.UserId)).LastName;
                    mbi.Length = mbi.Length;
                    mbi.Chest = mbi.Chest;
                    mbi.Id = mbi.Id;
                    mbi.Leg = mbi.Leg;
                    mbi.UserId = mbi.UserId;
                    mbi.Weight = mbi.Weight;
                }
                return mappedBodyInformationListModel;
            }
        }
    }
}
