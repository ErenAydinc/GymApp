using Application.Features.MemberTypes.Constants;
using Application.Features.MemberTypes.Dtos;
using Application.Features.MemberTypes.Rules;
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

namespace Application.Features.MemberTypes.Commands.CreateMemberType
{
    public class CreateMemberTypeCommand:IRequest<CreateMemberTypeDto>,ISecuredRequest
    {
        public string Name { get; set; }

        public string[] Roles { get; } =
        {
            MemberTypeRoles.MemberTypeCreate,
            MemberTypeRoles.MemberTypeAdmin
        };

        public class CreateMemberTypeCommandHandler : IRequestHandler<CreateMemberTypeCommand, CreateMemberTypeDto>
        {
            private readonly IMemberTypeRepository _memberTypeRepository;
            private readonly MemberTypeBusinessRules _memberTypeBusinessRules;
            private readonly IMapper _mapper;
            public CreateMemberTypeCommandHandler(IMemberTypeRepository memberTypeRepository, MemberTypeBusinessRules memberTypeBusinessRules, IMapper mapper)
            {
                _memberTypeRepository = memberTypeRepository;
                _memberTypeBusinessRules = memberTypeBusinessRules;
                _mapper = mapper;
            }
            public async Task<CreateMemberTypeDto> Handle(CreateMemberTypeCommand request, CancellationToken cancellationToken)
            {
                await _memberTypeBusinessRules.MemberTypeNameExists(request.Name);

                MemberType? memberType = _mapper.Map<MemberType>(request);

                MemberType mappedMemberType = await _memberTypeRepository.AddAsync(memberType);

                CreateMemberTypeDto createMemberTypeDto = _mapper.Map<CreateMemberTypeDto>(mappedMemberType);

                return createMemberTypeDto;
            }
        }
    }
}
