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

namespace Application.Features.BodyInformations.Commands.CreateBodyInformation
{
    public class CreateBodyInformationCommand : IRequest<CreateBodyInformationDto>, ISecuredRequest
    {
        public int UserId { get; set; }
        public float Length { get; set; }
        public float Weight { get; set; }
        public float Arm { get; set; }
        public float Shoulder { get; set; }
        public float Leg { get; set; }
        public float Chest { get; set; }

        public string[] Roles { get; } =
        {
            BodyInformationRoles.BodyInformationAdmin,
            BodyInformationRoles.BodyInformationCreate
        };

        public class CreateBodyInformationCommandHandler : IRequestHandler<CreateBodyInformationCommand, CreateBodyInformationDto>
        {
            private readonly IBodyInformationRepository _bodyInformationRepository;
            private readonly BodyInformationBusinessRules _bodyInformationBusinessRules;
            private readonly IMapper _mapper;

            public CreateBodyInformationCommandHandler(IBodyInformationRepository bodyInformationRepository, BodyInformationBusinessRules bodyInformationBusinessRules, IMapper mapper)
            {
                _bodyInformationRepository = bodyInformationRepository;
                _bodyInformationBusinessRules = bodyInformationBusinessRules;
                _mapper = mapper;
            }

            public async Task<CreateBodyInformationDto> Handle(CreateBodyInformationCommand request, CancellationToken cancellationToken)
            {
                await _bodyInformationBusinessRules.UserIdAlreadyExists(request.UserId);

                BodyInformation? mappedBodyInformation = _mapper.Map<BodyInformation>(request);

                BodyInformation createBodyInformation = await _bodyInformationRepository.AddAsync(mappedBodyInformation);

                CreateBodyInformationDto createBodyInformationDto = _mapper.Map<CreateBodyInformationDto>(createBodyInformation);

                return createBodyInformationDto;
            }
        }
    }
}
