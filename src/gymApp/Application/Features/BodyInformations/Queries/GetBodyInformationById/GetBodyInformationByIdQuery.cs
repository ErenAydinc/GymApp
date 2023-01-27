using Application.Features.BodyInformations.Dtos;
using Application.Features.BodyInformations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BodyInformations.Queries.GetBodyInformationById
{
    public class GetBodyInformationByIdQuery:IRequest<GetBodyInformationByIdDto>
    {
        public int Id { get; set; }
        public class GetBodyInformationByIdQueryHandler:IRequestHandler<GetBodyInformationByIdQuery, GetBodyInformationByIdDto>
        {
            private readonly IBodyInformationRepository _bodyInformationRepository;
            private readonly BodyInformationBusinessRules _bodyInformationBusinessRules;
            private readonly IMapper _mapper;

            public GetBodyInformationByIdQueryHandler(IBodyInformationRepository bodyInformationRepository, BodyInformationBusinessRules bodyInformationBusinessRules, IMapper mapper)
            {
                _bodyInformationRepository = bodyInformationRepository;
                _bodyInformationBusinessRules = bodyInformationBusinessRules;
                _mapper = mapper;
            }

            public async Task<GetBodyInformationByIdDto> Handle(GetBodyInformationByIdQuery request, CancellationToken cancellationToken)
            {
                BodyInformation? bodyInformation= await _bodyInformationRepository.GetAsync(x => x.Id == request.Id);

                await _bodyInformationBusinessRules.IdNotExists(bodyInformation.Id);

                GetBodyInformationByIdDto getUserByIdDto = _mapper.Map<GetBodyInformationByIdDto>(bodyInformation);

                return getUserByIdDto;
            }
        }
    }
}
