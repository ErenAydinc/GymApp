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

namespace Application.Features.MemberTypes.Commands.UpdateMemberType
{
    public class UpdateMemberTypeCommand:IRequest<UpdateMemberTypeDto>,ISecuredRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string[] Roles { get; } =
        {
            MemberTypeRoles.MemberTypeUpdate,
            MemberTypeRoles.MemberTypeAdmin
        };

        public class UpdateMemberTypeCommandHandler : IRequestHandler<UpdateMemberTypeCommand, UpdateMemberTypeDto>
        {
            private readonly IMemberTypeRepository _memberTypeRepository;
            private readonly MemberTypeBusinessRules _memberTypeBusinessRules;
            private readonly IMapper _mapper;
            public UpdateMemberTypeCommandHandler(IMemberTypeRepository memberTypeRepository, MemberTypeBusinessRules memberTypeBusinessRules, IMapper mapper)
            {
                _memberTypeRepository = memberTypeRepository;
                _memberTypeBusinessRules = memberTypeBusinessRules;
                _mapper = mapper;
            }
            public async Task<UpdateMemberTypeDto> Handle(UpdateMemberTypeCommand request, CancellationToken cancellationToken)
            {
                await _memberTypeBusinessRules.MemberTypeNotExists(request.Id);

                MemberType? memberType = _mapper.Map<MemberType>(request);

                MemberType mappedMemberType = await _memberTypeRepository.UpdateAsync(memberType);

                UpdateMemberTypeDto updateMemberTypeDto = _mapper.Map<UpdateMemberTypeDto>(mappedMemberType);

                return updateMemberTypeDto;
            }
        }
    }
}
