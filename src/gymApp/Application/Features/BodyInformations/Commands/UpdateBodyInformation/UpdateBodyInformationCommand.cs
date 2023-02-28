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

namespace Application.Features.BodyInformations.Commands.UpdateBodyInformation
{
    public class UpdateBodyInformationCommand:IRequest<UpdateBodyInformationDto>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public float Length { get; set; }
        public float Weight { get; set; }
        public float Arm { get; set; }
        public float Shoulder { get; set; }
        public float Leg { get; set; }
        public float Chest { get; set; }

        public class UpdateBodyInformationCommandHandler : IRequestHandler<UpdateBodyInformationCommand, UpdateBodyInformationDto>
        {
            private readonly IBodyInformationRepository _bodyInformationRepository;
            private readonly BodyInformationBusinessRules _bodyInformationBusinessRules;
            private readonly IMapper _mapper;

            public UpdateBodyInformationCommandHandler(IBodyInformationRepository bodyInformationRepository, BodyInformationBusinessRules bodyInformationBusinessRules, IMapper mapper)
            {
                _bodyInformationRepository = bodyInformationRepository;
                _bodyInformationBusinessRules = bodyInformationBusinessRules;
                _mapper = mapper;
            }

            public async Task<UpdateBodyInformationDto> Handle(UpdateBodyInformationCommand request, CancellationToken cancellationToken)
            {
                await _bodyInformationBusinessRules.IdNotExists(request.Id);
                await _bodyInformationBusinessRules.UserIdNotExists(request.UserId);
                
                BodyInformation? mappedBodyInformation = _mapper.Map<BodyInformation>(request);

                BodyInformation updateBodyInformation = await _bodyInformationRepository.UpdateAsync(mappedBodyInformation);

                UpdateBodyInformationDto updateBodyInformationDto =_mapper.Map<UpdateBodyInformationDto>(updateBodyInformation);

                return updateBodyInformationDto;
            }
        }
    }
}
