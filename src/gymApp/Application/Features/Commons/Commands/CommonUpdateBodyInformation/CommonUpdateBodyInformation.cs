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

namespace Application.Features.Commons.Commands.CommonUpdateCommonBodyInformation
{

    public class UpdateCommonBodyInformationCommand : IRequest<CommonUpdateBodyInformationDto>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public float Length { get; set; }
        public float Weight { get; set; }
        public float Arm { get; set; }
        public float Shoulder { get; set; }
        public float Leg { get; set; }
        public float Chest { get; set; }

        public class UpdateCommonBodyInformationCommandHandler : IRequestHandler<UpdateCommonBodyInformationCommand, CommonUpdateBodyInformationDto>
        {
            private readonly IBodyInformationRepository _bodyInformationRepository;
            private readonly IMapper _mapper;

            public UpdateCommonBodyInformationCommandHandler(IBodyInformationRepository bodyInformationRepository, IMapper mapper)
            {
                _bodyInformationRepository = bodyInformationRepository;
                _mapper = mapper;
            }

            public async Task<CommonUpdateBodyInformationDto> Handle(UpdateCommonBodyInformationCommand request, CancellationToken cancellationToken)
            {

                BodyInformation? mappedBodyInformation= _mapper.Map<BodyInformation>(request);

                BodyInformation createBodyInformation = await _bodyInformationRepository.UpdateAsync(mappedBodyInformation);

                CommonUpdateBodyInformationDto commonUpdateBodyInformationDto= _mapper.Map<CommonUpdateBodyInformationDto>(createBodyInformation);

                return commonUpdateBodyInformationDto;
            }
        }
    }
}
