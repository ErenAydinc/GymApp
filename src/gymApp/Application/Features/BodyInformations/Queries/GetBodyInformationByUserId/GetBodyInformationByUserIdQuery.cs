using Application.Features.BodyInformations.Constants;
using Application.Features.BodyInformations.Dtos;
using Application.Features.BodyInformations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BodyInformations.Queries.GetBodyInformationByUserId
{
    public class GetBodyInformationByUserIdQuery:IRequest<GetBodyInformationByUserIdDto>
    {
        public int UserId { get; set; }

        public class GetBodyInformationByUserIdQueryHandler:IRequestHandler<GetBodyInformationByUserIdQuery, GetBodyInformationByUserIdDto>
        {
            private readonly IBodyInformationRepository _bodyInformationRepository;
            private readonly BodyInformationBusinessRules _bodyInformationBusinessRules;
            private readonly IMapper _mapper;

            public GetBodyInformationByUserIdQueryHandler(IBodyInformationRepository bodyInformationRepository, BodyInformationBusinessRules bodyInformationBusinessRules, IMapper mapper)
            {
                _bodyInformationRepository = bodyInformationRepository;
                _bodyInformationBusinessRules = bodyInformationBusinessRules;
                _mapper = mapper;
            }

            public async Task<GetBodyInformationByUserIdDto> Handle(GetBodyInformationByUserIdQuery request, CancellationToken cancellationToken)
            {
                BodyInformation? bodyInformation= await _bodyInformationRepository.GetAsync(x => x.UserId == request.UserId);

                GetBodyInformationByUserIdDto getUserByUserIdDto = _mapper.Map<GetBodyInformationByUserIdDto>(bodyInformation);

                return getUserByUserIdDto;
            }
        }
    }
}
