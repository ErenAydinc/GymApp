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

namespace Application.Features.BodyInformations.Commands.DeleteBodyInformation
{
    public class DeleteBodyInformationCommand:IRequest<DeleteBodyInformationDto>
    {
        public int Id { get; set; }

        public class DeleteBodyInformationCommandHandler : IRequestHandler<DeleteBodyInformationCommand, DeleteBodyInformationDto>
        {
            private readonly IBodyInformationRepository _bodyInformationRepository;
            private readonly BodyInformationBusinessRules _bodyInformationBusinessRules;
            private readonly IMapper _mapper;

            public DeleteBodyInformationCommandHandler(IBodyInformationRepository bodyInformationRepository, BodyInformationBusinessRules bodyInformationBusinessRules, IMapper mapper)
            {
                _bodyInformationRepository = bodyInformationRepository;
                _bodyInformationBusinessRules = bodyInformationBusinessRules;
                _mapper = mapper;
            }

            public async Task<DeleteBodyInformationDto> Handle(DeleteBodyInformationCommand request, CancellationToken cancellationToken)
            {
                await _bodyInformationBusinessRules.IdNotExists(request.Id);
                
                BodyInformation? mappedBodyInformation = _mapper.Map<BodyInformation>(request);

                BodyInformation deleteBodyInformation = await _bodyInformationRepository.DeleteAsync(mappedBodyInformation);

                DeleteBodyInformationDto deleteBodyInformationDto =_mapper.Map<DeleteBodyInformationDto>(deleteBodyInformation);

                return deleteBodyInformationDto;
            }
        }
    }
}
