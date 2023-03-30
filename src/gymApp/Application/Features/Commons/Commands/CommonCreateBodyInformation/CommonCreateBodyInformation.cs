using Application.Features.Commons.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commons.Commands.CommonCreateCommonBodyInformation
{

    public class CreateCommonBodyInformationCommand : IRequest<CommonCreateBodyInformationDto>
    {
        public int UserId { get; set; }
        public float Length { get; set; }
        public float Weight { get; set; }
        public float Arm { get; set; }
        public float Shoulder { get; set; }
        public float Leg { get; set; }
        public float Chest { get; set; }

        public class CreateCommonBodyInformationCommandHandler : IRequestHandler<CreateCommonBodyInformationCommand, CommonCreateBodyInformationDto>
        {
            private readonly IBodyInformationRepository _bodyInformationRepository;
            //private readonly CommonBodyInformationBusinessRules _CommonBodyInformationBusinessRules;
            private readonly IMapper _mapper;

            public CreateCommonBodyInformationCommandHandler(IBodyInformationRepository bodyInformationRepository, IMapper mapper)
            {
                _bodyInformationRepository = bodyInformationRepository;
                _mapper = mapper;
            }

            public async Task<CommonCreateBodyInformationDto> Handle(CreateCommonBodyInformationCommand request, CancellationToken cancellationToken)
            {

                BodyInformation? mappedBodyInformation= _mapper.Map<BodyInformation>(request);

                BodyInformation createBodyInformation = await _bodyInformationRepository.AddAsync(mappedBodyInformation);

                CommonCreateBodyInformationDto commonCreateBodyInformationDto= _mapper.Map<CommonCreateBodyInformationDto>(createBodyInformation);

                return commonCreateBodyInformationDto;
            }
        }
    }
}
